using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using AbsentManagement.Areas.Admin.Data;
using AbsentManagement.Areas.Admin.Data.Request;
using AbsentManagement.Areas.Admin.Utils;
using AbsentManagement.Areas.Home.Data.Enums;
using AbsentManagement.Models;
using Microsoft.Ajax.Utilities;

namespace AbsentManagement.Areas.Admin
{
    public class AdminHomeService
    {
        private DbConnection dbConnection;
        public AdminHomeService(DbConnection dbConnection) {
            this.dbConnection = dbConnection;
        }

        public List<DayOffDTO> absentList(FilterRequest filter)
        {
            var query = dbConnection.DayOffs.Include(x => x.Person).Include(x => x.Person.information);
            query=this.search(filter.StudentName, query);
            query=this.sortedList(filter.SortField, filter.SortType, query);
            filter.TotalPage = (query.Count() / filter.PageSize);
            filter.TotalPage=filter.TotalPage>0 ? filter.TotalPage+1 : 1;
            query =this.pagination(filter.PageIndex, filter.PageSize, query);
            return this.setReponse(query.ToList());
        }

        private IQueryable<DayOff> sortedList(string field, string sortType,IQueryable<DayOff> query)
        {
            switch (field)
            {
                case "status":
                    query=query.OrderBy(x => x.created_at).OrderBy(x => x.approve_status);
                    break;
                default:
                    break;
            }

            if (sortType.Equals("desc"))
            {
                query = query.OrderBy(x => x.created_at).OrderByDescending(x => x.approve_status);
            }
            return query;
        }

        private IQueryable<DayOff> search(string key, IQueryable<DayOff> query)
        {
            if (!key.IsEmpty())
            {
                query = query.Where(x => x.Person.information.last_name.Contains(key));
            }
            return query;    
        }

        private IQueryable<DayOff> pagination(int pageIndex, int pageSize, IQueryable<DayOff> query)
        {
            return query.Skip(pageSize*(pageIndex-1)).Take(pageSize); 
        }

        public void setFilterRequest(FilterRequest filter)
        {
            if(filter == null) filter = new FilterRequest();
            if (filter.StudentName ==null) filter.StudentName="";
            if (filter.SortField==null) filter.SortField="status";
            if (filter.SortType==null) filter.SortType="asc";
            if (filter.PageIndex==0) filter.PageIndex=1;
            if (filter.PageSize==0) filter.PageSize=10;
            if(filter.TotalPage==0) filter.TotalPage=1;
        }

        public void updateApproveStatus(int id)
        {
            var dayOff = dbConnection.DayOffs.Find(id);
            dayOff.approve_status = AbsentLogStatusEnum.APPROVED;
            dbConnection.DayOffs.AddOrUpdate(dayOff);
            dbConnection.SaveChanges();
        }

        private List<DayOffDTO> setReponse(List<DayOff> entities)
        {
            string pattern = "dd-MM-yyyy";
            List<DayOffDTO> dayOffDTOs = new List<DayOffDTO>();
            foreach (DayOff entity in entities)
            {
                DayOffDTO dayOffDTO = new DayOffDTO();
                string from = DateUtils.parseString(pattern, entity.date_from);
                string to = DateUtils.parseString(pattern, entity.date_to);
                dayOffDTO.FromTo=from+" -> "+to;
                dayOffDTO.StudentName=entity.Person.information.last_name +" "+entity.Person.information.first_name;
                dayOffDTO.Reason=entity.reason;
                dayOffDTO.Status=AbsentLogStatusEnum.getKey(entity.approve_status);
                dayOffDTO.Id = entity.id;
                dayOffDTOs.Add(dayOffDTO);
            }

            return dayOffDTOs;
        } 
    }
}