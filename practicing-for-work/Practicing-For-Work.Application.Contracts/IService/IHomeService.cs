using Practicing_For_Work.Application.Contracts.Dtos;
using Practicing_For_Work.Application.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practicing_For_Work.Application.Contracts.IService
{
    public interface IHomeService
    {
        /// <summary>
        /// 產生會員帳號
        /// </summary>
        /// <returns></returns>
        Task<ApplicationResult<Member>> CreateAsync(SignupDto dto);

        /// <summary>
        /// 驗證會員
        /// </summary>
        /// <returns></returns>
        Task<ApplicationResult<Member>> IsValidateAsync(SigninDto dto);

        Task<Member> FindByAccountAsync(string account);
    }
}
