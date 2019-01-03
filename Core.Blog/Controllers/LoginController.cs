using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Blog.Application.Dtos;
using Core.Blog.AutoHelper.OverWrite;
using Core.Blog.Common;
using Core.Blog.Core.Models;
using Core.Blog.EntityFramework;
using Core.Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core.Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BlogDbContext _context;
        public LoginController(BlogDbContext context)
        {
            _context = context;
        }
      
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            //dto = new UserLoginDto { Email = "377749229@qq.com", PassWord = "123456" };
            SimpleMessage<string> message = new SimpleMessage<string>();
            try
            {
                if (dto == null)
                    return NotFound();
                //找到邮箱
                UserInfo student = await _context.UserInfo.Where(s => s.Email == dto.Email).AsNoTracking()
                    .FirstOrDefaultAsync();
                if (student == null)
                {
                    throw new Exception("未查找到用户信息");
                }

                //匹配密码
                if (student.PassWord != Encryption.MD5Hash(dto.PassWord + "." + student.PassKey))
                {
                    throw new Exception("用户名密码错误");
                }

                //添加生成token
                TokenModelJWT tokenModel = new TokenModelJWT();
                tokenModel.id = student.ID;
                tokenModel.Role = student.Role;
                tokenModel.Work = "人员";

                message.data = JwtHelper.IssueJWT(tokenModel);


            }
            catch (Exception ex)
            {
                message.InfoMessage(ex.Message);
            }
            return Content(message.ToJson());
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            SimpleMessage<string> message = new SimpleMessage<string>();
            try
            {
                if (dto == null)
                    return NotFound();

                UserInfo userInfo = await _context.UserInfo.Where(s => s.Email == dto.Email).AsNoTracking().FirstOrDefaultAsync();

                if (userInfo != null)
                    throw new Exception("邮箱已经注册");
                if (userInfo != null && userInfo.UserName == dto.UserName)
                    throw new Exception("用户名被使用");

                //添加
                userInfo = new UserInfo();
                userInfo.UserName = dto.UserName;
                userInfo.Email = dto.Email;
                userInfo.PassWord = dto.PassWord;
                userInfo.PassKey = Guid.NewGuid().ToString();
                userInfo.PassWord = Encryption.MD5Hash(dto.PassWord + "." + userInfo.PassKey);
                userInfo.BlogUrl = dto.BlogUrl;
                userInfo.LoveSentence = dto.LoveSentence;
                userInfo.HeadUrl = dto.HeadUrl;
                userInfo.CreateTime = DateTime.Now;
                userInfo.LastErrTime = DateTime.Now;
                userInfo.Role = "用户";

                //注册
                _context.Add(userInfo);
                await _context.SaveChangesAsync();

                //添加生成token
                TokenModelJWT tokenModel = new TokenModelJWT();
                tokenModel.id = userInfo.ID;
                tokenModel.Role = userInfo.Role;
                tokenModel.Work = "用户";
                message.data = JwtHelper.IssueJWT(tokenModel);

            }
            catch (Exception ex)
            {
                message.InfoMessage(ex.Message);
            }
            return Content(message.ToJson());

        }

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "用户")]
        public async Task<IActionResult> Initialize()
        {
            SimpleMessage<UserInfoDto> message = new SimpleMessage<UserInfoDto>();
            try
            {
                //进行token验证
                TokenModelJWT tokenModel = TokenJwtAop.GetToken(HttpContext);
                //获取用户信息
                UserInfoDto userInfo = _context.UserInfo.Where(s => s.ID == tokenModel.id).Select(s => new UserInfoDto
                {
                    username = s.UserName,
                    email = s.Email,
                    bolgurl = s.BlogUrl,
                    lovesentence = s.LoveSentence,
                    headurl = s.HeadUrl,
                }).FirstOrDefault();


                message.data = userInfo;

            }
            catch (Exception ex)
            {
                message.InfoMessage(ex.Message);
            }

            return Content(message.ToJson());
        }
    }
}
