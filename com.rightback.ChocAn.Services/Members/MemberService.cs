using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;
using System.Data.Entity;

namespace com.rightback.ChocAn.Services.Members
{
    public class MemberService : BaseService, IMemberService
    {
        public void deleteMember(string code)
        {
            if (code == null)
                throw new ArgumentNullException();
            var member = db.Members.Where(m => m.Code.Equals(code)).FirstOrDefault();
            if (member != null)
            {
                db.Members.Remove(member);
                db.SaveChanges();
            }
            else
                throw new KeyNotFoundException();

        }

        public DbSet<Member> getAllMembers()
        {
            return db.Members;
        }

        public Member getByCode(string code)
        {
            if (code == null)
                throw new ArgumentNullException();
            return db.Members
                .Where(m => m.Code.Equals(code))
                .FirstOrDefault();
        }

        public Member getById(int Id)
        {

            return db.Members
              .Where(m => m.MemberID.Equals(Id))
              .FirstOrDefault();
        }

        public IQueryable<Member> getMembersWhoConsultedWithin(DateTime start, DateTime end)
        {
            return from u in db.Claims.Where(e => e.DateOfClaim > start & e.DateOfClaim < end) select u.Member;
        }

        public IQueryable<Member> getMembersWhoContains(string keyWord)
        {
            return (from u in db.Members.Where(e => e.Name.Contains(keyWord)
                    || e.Code.Contains(keyWord)
                    || e.Zip.Contains(keyWord)
                    || e.Status.ToString().Contains(keyWord)
                    || e.State.ToString().Contains(keyWord)
                    || e.StreetAddres.Contains(keyWord)
                    || e.Email.Contains(keyWord)
                    || e.City.Contains(keyWord))
                    select u).Distinct();
        }

        public void upsertMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException();
            if (member.Code == null)
                throw new ArgumentNullException("Code", "Member code is missing");


            var memberSearch = getByCode(member.Code);
            if (memberSearch == null)
            {
                db.Members.Add(member);
            }
            else
            {
                //using AddOrUpdate method is not safe as it may insert dublicate records
                memberSearch.Name = member.Name;
                memberSearch.City = member.City;
                memberSearch.Code = member.Code;
                memberSearch.Email = member.Email;
                memberSearch.Status = member.Status;
                memberSearch.Zip = member.Zip;
                memberSearch.StreetAddres = member.StreetAddres;

            }
            db.SaveChanges();
        }


    }
}
