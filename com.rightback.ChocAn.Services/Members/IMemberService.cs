using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Members
{
    public interface IMemberService
    {
        /// <summary>
        /// Returns member by 9 digit member code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Member getByCode(string code);


        /// <summary>
        /// Returns Member by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Member</returns>
        Member getById(int Id);

        /// <summary>
        /// insert new member or update if id existed.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        void upsertMember(Member member);

        /// <summary>
        /// Returns all members.
        /// </summary>
        /// <returns> DbSet </returns>
        DbSet<Member> getAllMembers();

        /// <summary>
        ///Delete member .
        /// </summary>
        /// <param name="Code"></param>
        /// <returns> </returns>
        void deleteMember(string code);

        /// <summary>
        /// Returns Members who consulted within specific range
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns>IQueryable<Member></returns>
        IQueryable<Member> getMembersWhoConsultedWithin(DateTime start, DateTime end);

        /// <summary>
        /// Returns Members who has the giving keyword in thier records
        /// </summary>
        /// <param name="KeyWord"></param>
        /// <returns>IQueryable<Member></returns>
        IQueryable<Member> getMembersWhoContains(string keyWord);


    }
}
