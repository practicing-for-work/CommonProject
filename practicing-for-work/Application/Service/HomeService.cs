using Arch.EntityFrameworkCore.UnitOfWork;
using Practicing_For_Work.Application.Contracts;
using Practicing_For_Work.Application.Contracts.Dtos;
using Practicing_For_Work.Application.Contracts.IService;
using Practicing_For_Work.Application.Contracts.Model;
using Practicing_For_Work.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class HomeService : ServiceBase, IHomeService
    {
        private readonly IRepository<FdMember> _memberRepository;

        public HomeService(IServiceProvider serviceProvider)
            : base(serviceProvider) 
        {
            _memberRepository = _unitOfWork.GetRepository<FdMember>();
        }

        public async Task<ApplicationResult<Member>> CreateAsync(SignupDto dto) 
        {
            var member = await FindByAccountAsync(dto.Account);

            if (member == null) 
            {
                return ApplicationResult<Member>.Failed(new ApplicationError
                {
                    Code = nameof(Member.Account),
                    Description = "會員已存在!"
                });
            }

            var newMemberSeq = Guid.NewGuid();
            var newMember = new FdMember()
            {
                MemberSeq = newMemberSeq,
                Account = dto.Account,
                Password = dto.Password,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            await _memberRepository.InsertAsync(newMember);

            var effectRows = await _unitOfWork.SaveChangesAsync();

            var result = effectRows > 0 ? ApplicationResult<Member>.Success : ApplicationResult<Member>.Failed();
            if (result.Succeeded)
            {
                result.Data = _mapper.Map<Member>(newMember);
            }

            return result;

        }
        public async Task<ApplicationResult<Member>> IsValidateAsync(SigninDto dto)
        {
            var member =  _memberRepository.GetFirstOrDefault(predicate: x => x.Account == dto.Account);

            if (member == null)
            {
                return ApplicationResult<Member>.Failed(new ApplicationError
                {
                    Code = nameof(Member.Account),
                    Description = "會員不存在!!"
                });
            }

            if (member.Account != dto.Account) 
            {
                var failed = ApplicationResult<Member>.Failed(
                   new ApplicationError
                   {
                       Code = nameof(member.Password),
                       Description = "輸入密碼錯誤!!"
                   }
               );

                failed.Data = _mapper.Map<Member>(member);

                return failed;
            }

            var success = ApplicationResult<Member>.Success;
            success.Data = _mapper.Map<Member>(member);

            return success;
        }

        public async Task<Member> FindByAccountAsync(string account)
        {
            var htMember = await _memberRepository.GetFirstOrDefaultAsync(predicate: x => x.Account == account);

            var member = _mapper.Map<Member>(htMember);

            return member;
        }
    }
}
