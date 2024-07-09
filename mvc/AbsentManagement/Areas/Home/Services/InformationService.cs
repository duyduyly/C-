using AbsentManagement.Areas.Home.Data.DTOs;
using AbsentManagement.Models;
using AbsentManagement.Models.DTOs;
using AbsentManagement.Services;
using AbsentManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Home.Services
{
    public class InformationService
    {
        private FileUtils fileUtils;
        private DbConnection dbConnection;
        private UserSessonDTO userSessonDTO = LoginService.getUser();

        public InformationService(FileUtils fileUtils, DbConnection dbConnection) {
            this.fileUtils = fileUtils;
            this.dbConnection = dbConnection;
        } 

        public InformationDTO get(long userId)
        {
            var information = dbConnection.information.Include(x => x.Person).Where(x => x.Person.account_id==userId).FirstOrDefault();

            if (information != null)
            {
                InformationDTO informationDTO = new InformationDTO();
                var birthday = information.birthday;
                informationDTO.Id =information.person_id;
                informationDTO.FirstName=information.first_name;
                informationDTO.LastName = information.last_name;
                informationDTO.Birthday=birthday!= DateTime.MinValue ? birthday.Value : DateTime.MinValue;
                informationDTO.Address = information.address;
                informationDTO.AvatarUrl=information.avartar_url;
                return informationDTO;
            }
            return new InformationDTO();
        }

        public bool update(InformationDTO informationDTO)
        {
            var information = dbConnection.information.Where(x => x.person_id==informationDTO.Id).FirstOrDefault();
            if (information!=null)
            {
                information.first_name=informationDTO.FirstName;
                information.last_name=informationDTO.LastName;
                information.address=informationDTO.Address;
                information.birthday=informationDTO.Birthday;
                information.updated_at=DateTime.Now;
                information.updated_by=userSessonDTO.userId;
                if (informationDTO.Avatar!=null)
                {
                    string avatarUrl = fileUtils.addFile(informationDTO.Avatar, informationDTO.FirstName+informationDTO.LastName);
                    information.avartar_url=avatarUrl;

                    dbConnection.information.AddOrUpdate(information);
                    dbConnection.SaveChanges();
                }
                return true;
            }

            return false;
        }
    }
}