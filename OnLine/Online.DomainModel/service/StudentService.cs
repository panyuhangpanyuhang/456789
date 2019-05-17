using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Online.Infrastructure.MyCourse;

namespace Online.DomainModel
{
    public class StudentService
    {
        #region Action
        /// <summary>
        /// 获取列表信息
        /// </summary>
        public List<Student> GetAll()
        {
            List<Student> students = null;
            using (var dbContext = new OnlineContext())
            {
                students = dbContext.Student.ToList();
            }
            return students;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        public int StudentAdd(int sid,string sname,string depart,string Class,string major,string password)
        {
            int count = 0;

            var user = new Student()
            {
                Sid =sid,
                Sname=sname,
                Depart=depart,
                Class=Class,
                Major=major,
                Password=password,


            };
      
            using (var dbContext = new OnlineContext())
            {
                dbContext.Student.Add(user);
                count = dbContext.SaveChanges();
            }
            return count;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int StudentDel(int sid)
        {
            int count = 0;
            Student student = new Student()
            {
                Sid = sid,
            };
            //标记为删除状态
            using (var dbContext = new OnlineContext())
            {
                student = dbContext.Student.FirstOrDefault(x => x.Sid == sid);
                dbContext.Student.Remove(student);
                dbContext.SaveChanges();
                count = 1;
            }
            return count;
        }
        /// <summary>
        /// 通过姓名查找用户
        /// </summary>
        public List<Student> GetUserByName(string sname)
        {
            List<Student> users=null;
            using (var dbContext = new OnlineContext())
            {
                users = dbContext.Student.Where(x=>x.Sname==sname).ToList();
            }
            return users;
        }
        /// <summary>
        /// 通过ID查找用户
        /// </summary>
        public Student GetUserById(int sid)
        {
            Student user = null;
            using (var dbContext = new OnlineContext())
            {
                user = dbContext.Student.FirstOrDefault(x => x.Sid == sid);
                //取序列中满足条件的第一个元素，如果没有元素满足条件，则返回默认值
            }
            return user;
        }
        //public Student GetUserByEmail(string email)
        //{
        //    Student user = null;
        //    using (var dbContext = new OnlineContext())
        //    {
        //        user = dbContext.Student.FirstOrDefault(x => x.Email == email);
        //        //取序列中满足条件的第一个元素，如果没有元素满足条件，则返回默认值
        //    }
        //    return user;
        //}
        /// <summary>
        /// 修改用户信息
        /// </summary>
        public string UpdateUser(int sid, string sname, string depart, string Class, string major, string password)
        {

            //标记为修改状态
            using (var dbContext = new OnlineContext())
            {
                var user = dbContext.Student.FirstOrDefault(x => x.Sid == sid);
                user.Sname = sname;
                user.Depart = depart;
                user.Class = Class;
                user.Major = major;
                user.Password = password;
                dbContext.Student.Update(user);
                dbContext.SaveChanges();//保存改变
            }
            return "修改成功！";
        }
        #endregion
    }
}
