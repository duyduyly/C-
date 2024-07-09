using AbsentManagement.Areas.Home.Data.DTO;
using AbsentManagement.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using AbsentManagement.Areas.Home.Data.DTOs.AbsentLog;
using AbsentManagement.Models;
using System.Data.Entity.Migrations;
using System;
using System.Data.Entity;
using AbsentManagement.Areas.Home.Data.Enums;

namespace AbsentManagement.Areas.Home.Services
{
    public class HomeService
    {
        private AbsentManagement.Models.DbConnection dbConnection;

        private AbsentMapper absentMapper;

        public HomeService(AbsentManagement.Models.DbConnection dbConnection, AbsentMapper absentMapper)
        {
            this.dbConnection=dbConnection;
            this.absentMapper=absentMapper;
        }

        public void addAbsentLog(AbsentLogDTO absentLogDTO)
        {
            var student = dbConnection.People.Where(x => x.account_id==absentLogDTO.StudentId).FirstOrDefault();
            DayOff dayOff = absentMapper.createEntityFormDto(student, absentLogDTO);
            if (absentLogDTO.Id!=0) dayOff.id=absentLogDTO.Id;
            dbConnection.DayOffs.AddOrUpdate(dayOff);
            dbConnection.SaveChanges();
        }

        public List<AbsentLogDTO> findAbsentLog(long userid, int absentStatus)
        {
            Person student = dbConnection.People.Find(userid);
            List<AbsentLogDTO> list = new List<AbsentLogDTO>();
            var dayOffSelect = dbConnection.DayOffs.Include(x => x.Person).Include(x => x.Person.information)
                .Where(x => (x.person_id==userid&&x.approve_status==absentStatus)).OrderByDescending(x => x.created_at)
                .ToList();

            foreach (var day in dayOffSelect)
            {
                AbsentLogDTO absentLogDTO = absentMapper.entityToDto(day);
                list.Add(absentLogDTO);
            }
            return list;
        }

        public List<TeacherDTO> getAllTeacher()
        {
            List<TeacherDTO> teacherDTOs = new List<TeacherDTO>();
            var select = dbConnection.People.Include(x => x.information).Where(x => x.person_type==PersonEnum.TEACHER).ToList();
            foreach (var item in select)
            {
                TeacherDTO teacherDTO = new TeacherDTO();
                teacherDTO.Id=item.id;
                teacherDTO.Name=item.information.first_name;
                teacherDTOs.Add(teacherDTO);
            }
            return teacherDTOs;
        }

        public void remove(long id)
        {
            var student = dbConnection.DayOffs.Find(id);
            if (student==null) return;

            dbConnection.DayOffs.Remove(student);
            dbConnection.SaveChanges();
        }

        public AbsentLogDTO findById(long id)
        {
            var dayOff = dbConnection.DayOffs.Find(id);
            AbsentLogDTO absentlogDTO = new AbsentLogDTO();
            absentlogDTO.Id=id;
            absentlogDTO.From=dayOff.date_from;
            absentlogDTO.To=dayOff.date_to;
            absentlogDTO.TeacherId=dayOff.approve_person;
            absentlogDTO.Reason=dayOff.reason;
            return dayOff!=null ? absentlogDTO : new AbsentLogDTO();
        }

        public string getAvatarUrl(long user_id)
        {
            var information = dbConnection.information.Include(x => x.Person).Where(x => x.Person.account_id.Equals(user_id)).FirstOrDefault();
            return information.avartar_url;
        }


        public string validateDate(DateTime datetime1, DateTime datetime2)
        {
            DateTime now = DateTime.Now;
            now.AddDays(3);
            if (datetime1==null||datetime1==null) return Constant.DATE_ERROR_MESSAGE;
            if (datetime1==DateTime.MinValue||datetime1==DateTime.MinValue) return Constant.DATE_ERROR_MESSAGE;
            if (datetime1==DateTime.MaxValue||datetime1==DateTime.MaxValue) return Constant.DATE_ERROR_MESSAGE;
            if (datetime1.CompareTo(now)==-1) return Constant.DATE_GREATER_THAN_THREE_NOW;
            if (datetime2.CompareTo(now)==-1) return Constant.DATE_GREATER_THAN_THREE_NOW;
            if (datetime1.CompareTo(datetime2)==1) return Constant.DATE_FROM_GREATER_THAN_DATE_TO;
            return "";
        }
    }

}