using AbsentManagement.Areas.Home.Data.Enums;
using AbsentManagement.Models;
using AbsentManagement.Areas.Home.Data.DTOs.AbsentLog;
using System;

namespace AbsentManagement.Areas.Home.Data.DTO
{
    public class AbsentMapper
    {
        public DayOff createEntityFormDto(Person person, AbsentLogDTO absentLogDTO)
        {
            DayOff dayOff = new DayOff();
            dayOff.reason=absentLogDTO.Reason;
            dayOff.approve_person=absentLogDTO.TeacherId;
            dayOff.person_id=person.id;
            dayOff.date_from=absentLogDTO.From;
            dayOff.date_to=absentLogDTO.To;
            dayOff.approve_status= AbsentLogStatusEnum.PENDING;
            dayOff.created_at=DateTime.Now;
            dayOff.created_by=person.id;
            return dayOff;
        }

        public DayOff updateEnittyFromDto(Person person, AbsentLogDTO absentLogDTO)
        {
            DayOff dayOff = new DayOff();
            dayOff.reason=absentLogDTO.Reason;
            dayOff.approve_person=absentLogDTO.TeacherId;
            dayOff.person_id=person.id;
            dayOff.date_from=absentLogDTO.From;
            dayOff.date_to=absentLogDTO.To;
            dayOff.approve_status=AbsentLogStatusEnum.PENDING;
            dayOff.created_at=DateTime.Now;
            dayOff.created_by=person.id;
            return dayOff;
        }

        public AbsentLogDTO entityToDto(DayOff dayOff)
        {
            AbsentLogDTO absentLogDTO = new AbsentLogDTO();
            absentLogDTO.Id=dayOff.id;
            absentLogDTO.From=dayOff.date_from;
            absentLogDTO.To=dayOff.date_to;
            absentLogDTO.TeacherName=dayOff.Person.information.last_name;
            absentLogDTO.Status=AbsentLogStatusEnum.getKey(dayOff.approve_status);
            return absentLogDTO;
        }
    }
}
