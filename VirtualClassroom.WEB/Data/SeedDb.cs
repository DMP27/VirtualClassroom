using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassroom.Common.Entities;
using VirtualClassroom.Common.Enums;
using VirtualClassroom.WEB.Data.Entities;
using VirtualClassroom.WEB.Helpers;

namespace VirtualClassroom.WEB.Data
{
    public class SeedDb
    {

      

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this._context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            
            await CheckRolesAsync();
            //await CheckUserAsync("1010", "Daniel", "Munoz", "danielmunozparedes@gmail.com", "312 232 1364", "florencia", UserType.Admin,1);



            if (!_context.Users.Any())
            {
                await CheckUserAsync("1010", "Daniel", "Munoz", "danielmunozparedes@gmail.com", "312 232 1364", "florencia", UserType.Admin, 1);
                ////field 2
                //await CheckUserAsync("1011", "Carlos", "Munoz", "cml@yopmail.com", "312 232 1454", "florencia", UserType.Teacher, 6);
                //await CheckUserAsync("10542", "Cthulhu", "Entity cosmic", "cthulhu@yopmail.com", "311 455 4877", "R'lyeh", UserType.Teacher, 8);
                //await CheckUserAsync("10666", "Satan", "Beelzebub", "satan@yopmail.com", "666 666 6666", "Hell", UserType.Teacher, 9);
                //await CheckUserAsync("1997", "Andres", "Castillo", "andres@yopmail.com", "312 564 4545", "Robledo", UserType.Teacher, 10);

                ////field 1
                //await CheckUserAsync("1045", "Cristian", "Castro", "cristian@gmail.com", "389 875 9678", "Cali", UserType.Teacher, 1);
                //await CheckUserAsync("2325", "Andrea", "Benitez", "andrea@yopmail.com", "301 101 10001", "Tumaco", UserType.Teacher, 2);
                //await CheckUserAsync("3030", "Juliana", "Quiroz", "juliana@gmail.com", "311 111 1111", "Bogota", UserType.Teacher, 3);
                //await CheckUserAsync("7897", "Jesus", "Nazareth", "jesus@yopmail.com", "300 232 1232", "Bethlehem", UserType.Teacher, 5);

                //await CheckUserAsync("1045", "Cristian", "Castro", "cristian@gmail.com", "389 875 9678", "Cali", UserType.Teacher, 1);
                //await CheckUserAsync("2325", "Andrea", "Benitez", "andrea@yopmail.com", "301 101 10001", "Tumaco", UserType.Teacher, 2);
                //await CheckUserAsync("3030", "Juliana", "Quiroz", "juliana@gmail.com", "311 111 1111", "Bogota", UserType.Teacher, 3);
                //await CheckUserAsync("7897", "Jesus", "Nazareth", "jesus@yopmail.com", "300 232 1232", "Bethlehem", UserType.Teacher, 5);

                //F1 D1 I1
                await CheckUserAsync2("600", "1017", "Manuel", "Pinzon", "teacher1@yopmail.com", "345 457 7845", "Poblado", UserType.Teacher, 1);

                await CheckUserAsync2("601", "1018", "Martha", "Paredes", "martha@yopmail.com", "345 427 7845", "Poblado", UserType.User, 1);
                await CheckUserAsync2("602", "1019", "Juan", "Janico", "juan@yopmail.com", "333 457 7845", "Tumaco", UserType.User, 1);
                await CheckUserAsync2("603", "1020", "Carlos", "Lopez", "carlos@yopmail.com", "345 333 7845", "Poblado", UserType.User, 1);
                await CheckUserAsync2("604", "1021", "Miguel", "Blanco", "miguel@yopmail.com", "345 422 7845", "Florencia", UserType.User, 1);
                await CheckUserAsync2("605", "1022", "Jhon", "Castillo", "jhon@yopmail.com", "345 433 7845", "Poblado", UserType.User, 1);

                //F1 D1 I2
                await CheckUserAsync2("606", "1023", "Maria", "Meza", "teacher2@yopmail.com", "312 117 7845", "B. Nuevo", UserType.Teacher, 2);

                await CheckUserAsync2("607", "1024", "Henry", "Hammilton", "henry@yopmail.com", "355 666 6541", "Poblado", UserType.User, 2);
                await CheckUserAsync2("608", "1025", "Cristian", "Castro", "cristian@yopmail.com", "333 457 7845", "pasto", UserType.User, 2);
                await CheckUserAsync2("609", "1026", "James", "Hetfield", "james@yopmail.com", "125 333 7845", "Calle 14", UserType.User, 2);
                await CheckUserAsync2("610", "1027", "Juliana", "jimenez", "juliana@yopmail.com", "335 422 7845", "Florencia", UserType.User, 2);
                await CheckUserAsync2("611", "1028", "Abdul", "abdusam", "abdul@yopmail.com", "56785", "Iran", UserType.User, 2);


                //F1 D3 I3
                await CheckUserAsync2("618", "1997", "Andres", "Castillo", "teacher4@yopmail.com", "312 564 4545", "Robledo", UserType.Teacher, 4);

                await CheckUserAsync2("619", "1011", "Carlos", "Munoz", "cml@yopmail.com", "312 232 1454", "florencia", UserType.User, 4);
                await CheckUserAsync2("620", "10003", "Cristina", "Ampudia", "cristina@yopmail.com", "3333566 1666", "ecuador", UserType.User, 4);
                await CheckUserAsync2("621", "10004", "Ciro", "patiño", "ciro@yopmail.com", "323266", "N.45 calle 12223", UserType.User, 4);
                await CheckUserAsync2("622", "2325", "Hernan", "Benitez", "hernan@yopmail.com", "3000001", "Poblado", UserType.User, 4);
                await CheckUserAsync2("623", "3030", "Diana", "Quiroz", "diana@yopmail.com", "311 111 1111", "Bogota", UserType.User, 4);



                //F1 D3 I4
                await CheckUserAsync2("612", "1023", "Jesus", "Nazareth", "teacher3@yopmail.com", "312 117 7845", "Bethlehem", UserType.Teacher,5);
        
                await CheckUserAsync2("613", "10002", "Carolina", "Diaz", "carolina@yopmail.com", "300 566 1666", "Piedra ancha", UserType.User, 5);
                await CheckUserAsync2("614", "10003", "Tatiana", "Diaz", "tatiana@yopmail.com", "300 566 1666", "Piedra ancha", UserType.User, 5);
                await CheckUserAsync2("615", "10004", "Camilo", "patiño", "camilo@yopmail.com", "333 566 1666", "N.45 calle 123", UserType.User, 5);
                await CheckUserAsync2("616", "2325", "Andrea", "Benitez", "andrea@yopmail.com", "301 101 10001", "Tumaco", UserType.User, 5);
                await CheckUserAsync2("617", "3030", "Juliana", "Quiroz", "juliana2@yopmail.com", "311 111 1111", "Bogota", UserType.User, 5);


                //F2 D4 I5
                await CheckUserAsync2("624", "1997", "Camilo", "Castillo", "teacher5@yopmail.com", "312 564 4545", "Calle 43", UserType.Teacher, 6);

                await CheckUserAsync2("625", "1011", "Harold", "Munoz", "harold@yopmail.com", "31254", "calle 45-4", UserType.User, 6);
                await CheckUserAsync2("626", "1032003", "Jorge", "Ampudia", "jorge@yopmail.com", "3333566 1666", "ecuador", UserType.User, 6);
                await CheckUserAsync2("627", "100304", "Julian", "patiño", "julian@yopmail.com", "2323", "N.45 calle 122003", UserType.User, 6);
                await CheckUserAsync2("628", "232325", "Adrian", "ceron", "adrian@yopmail.com", "3000001", "Poblado", UserType.User, 6);
                await CheckUserAsync2("629", "3030", "Daniela", "Quiroz", "daniela@yopmail.com", "312210001", "Bogota", UserType.User, 6);



                //F2 D4 I6
                await CheckUserAsync2("630", "123997", "Andaluz", "Beltran", "teacher6@yopmail.com", "312 564 4545", "Cll 34-85", UserType.Teacher, 7);

                await CheckUserAsync2("631", "1011", "Sherlock", "Holmes", "sherlock@yopmail.com", "321454", "florencia", UserType.User, 7);
                await CheckUserAsync2("632", "100203", "Nianza", "Ampudia", "nianza@yopmail.com", "326 1666", "ecuador", UserType.User, 7);
                await CheckUserAsync2("633", "100304", "Norelly", "Angulo", "norelly@yopmail.com", "323266", "N.45 calle 13", UserType.User, 7);
                await CheckUserAsync2("634", "2325", "Alberto", "gonzalez", "alberto@yopmail.com", "3000001", "calle 345", UserType.User, 7);
                await CheckUserAsync2("635", "3030", "Dina", "Déas", "dina@yopmail.com", "3101", "Francia", UserType.User, 7);


                //F2 D6 I7
                await CheckUserAsync2("636", "194497", "Jhin", "Araujo", "teacher7@yopmail.com", "312 564 4545", "Calle 34-8", UserType.Teacher, 9);

                await CheckUserAsync2("637", "1011", "Pablo", "casas", "pablo@yopmail.com", "310", "florencia 45-5", UserType.User, 9);
                await CheckUserAsync2("638", "1002303", "Gina", "quiñones", "gina@yopmail.com", "30", "Tumaco", UserType.User, 9);
                await CheckUserAsync2("639", "100034", "Mario", "patiño", "mario@yopmail.com", "323266", "N.45 calle 2", UserType.User, 9);
                await CheckUserAsync2("640", "233225", "Mauricio", "guiase", "mauricio@yopmail.com", "30002001", "Poblado", UserType.User, 9);
                await CheckUserAsync2("641", "303220", "Bob", "Rock", "bob@yopmail.com", "35111", "USA", UserType.User, 9);



                //F2 D6 I8
                await CheckUserAsync2("642", "1922297", "Alejandro", "lim", "teacher8@yopmail.com", "3157", "USA", UserType.Teacher, 10);

                await CheckUserAsync2("643", "101231311", "Karen", "martin", "karen@yopmail.com", "312 232 1454", "florencia 458-88", UserType.User, 10);
                await CheckUserAsync2("644", "10122003", "Guillermo", "guampe", "guillermo@yopmail.com", "3331666", "Peru", UserType.User, 10);
                await CheckUserAsync2("645", "1033004", "Dario", "camacho", "dario@yopmail.com", "323266", "N.45 c3", UserType.User, 10);
                await CheckUserAsync2("646", "2121325", "Eliana", "cortes", "eliana@yopmail.com", "3000001", "Tumaco", UserType.User, 10);
                await CheckUserAsync2("647", "333030", "Luis", "Quiroz", "luis@yopmail.com", "21111", "Tumaco 12-2", UserType.User, 10);



                await CheckProfessionAsync();
                await CheckSubjectsAsync();
                //await  CheckUserSubjectsAsync();
                //await CheckMeetingAsync();
            }
            ////field 2
            //await CheckUserAsync("1011", "Carlos", "Munoz", "cml@yopmail.com", "312 232 1454", "florencia", UserType.Teacher, 6);
            //await CheckUserAsync("10542", "Cthulhu", "Entity cosmic", "cthulhu@yopmail.com", "311 455 4877", "R'lyeh", UserType.Teacher, 8);
            //await CheckUserAsync("10666", "Satan", "Beelzebub", "satan@yopmail.com", "666 666 6666", "Hell", UserType.Teacher, 9);
            //await CheckUserAsync("1997", "Andres", "Castillo", "andres@yopmail.com", "312 564 4545", "Robledo", UserType.Teacher, 10);

            ////field 1
            //await CheckUserAsync("1045", "Cristian", "Castro", "cristian@gmail.com", "389 875 9678", "Cali", UserType.Teacher, 1);
            //await CheckUserAsync("2325", "Andrea", "Benitez", "andrea@yopmail.com", "301 101 10001", "Tumaco", UserType.Teacher, 2);
            //await CheckUserAsync("3030", "Juliana", "Quiroz", "juliana@gmail.com", "311 111 1111", "Bogota", UserType.Teacher, 3);
            //await CheckUserAsync("7897", "Jesus", "Nazareth", "jesus@yopmail.com", "300 232 1232", "Bethlehem", UserType.Teacher, 5);




            //await CheckUserAsync2("789","10001", "Manuel", "Pinzon", "manuel@yopmail.com", "345 457 7845", "Poblado", UserType.User, 6);
            //await CheckUserAsync2("788","10002", "Carolina", "Diaz", "carolina@yopmail.com", "300 566 1666", "Piedra ancha", UserType.User, 6);

            //await CheckProfessionAsync();
            //await CheckMeetingAsync();


        }
        private async Task CheckProfessionAsync()
        {
            if (!_context.Professions.Any())
            {
                _context.Professions.Add(new Profession
                {
                    Name = "Student"
                });
                _context.Professions.Add(new Profession
                {
                    Name = "Proffesor"
                });
                await _context.SaveChangesAsync();
            }
        }







        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Teacher.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType,
            int church)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                    //Church = await _context.Churches.FindAsync(church)
                    //Church = _context.Churches.FirstOrDefault()
                    ,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }




        private async Task<User> CheckUserAsync2(
            string id,
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType,
            int church)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    //Church = await _context.Churches.FindAsync(church)
                    //Church = _context.Churches.FirstOrDefault()
                    

                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }



        //private async Task CheckMeetingAsync()
        //{

        //}





        //private async Task CheckFieldsAsync()
        //{
        //    if (!_context.Fields.Any())
        //    {
        //        _context.Fields.Add(new Field
        //        {
        //            Name = "Field 1",
        //            Districts = new List<District>
        //        {
        //            new District
        //            {
        //                Name = "District 1",
        //                Churches = new List<Church>
        //                {
        //                    new Church { Name = "Cathedral of the holy cross" },
        //                    new Church { Name = "Holy cross" }
        //                }
        //            },
        //            new District
        //            {
        //                Name = "District 2",
        //                Churches = new List<Church>
        //                {
        //                    new Church { Name = "Our lady of good voyage" }
        //                }
        //            },
        //            new District
        //            {
        //                Name = "District 3",
        //                Churches = new List<Church>
        //                {
        //                    new Church { Name = "Sacred heart" },
        //                    new Church { Name = "christ fellowship" }
        //                }
        //            }
        //        }
        //        });
        //        _context.Fields.Add(new Field
        //        {
        //            Name = "Field 2",
        //            Districts = new List<District>
        //        {
        //            new District
        //            {
        //                Name = "District 4",
        //                Churches = new List<Church>
        //                {
        //                    new Church { Name = "Metal church" },
        //                    new Church { Name = "Sacred reich" }
        //                }
        //            },
        //            new District
        //            {
        //                Name = "District 5",
        //                Churches = new List<Church>
        //                {
        //                    new Church { Name = "chtulhu's church" }
        //                }
        //            },
        //            new District
        //            {
        //                Name = "District 6",
        //                Churches = new List<Church>
        //                {
        //                    new Church { Name = "Left hand path" },
        //                    new Church { Name = "Last one on earth" }
        //                }
        //            }
        //        }
        //        });
        //        await _context.SaveChangesAsync();
        //    }

        //}





        private async Task CheckSubjectsAsync()
        {
            if (!_context.Subjects.Any())
            {
                _context.Subjects.Add(new Subject
                {
                   
                    Name = "Math" ,

                    UserSubjects = new List<UserSubject>
                    {
                                        new UserSubject {                                         
                                                           User = await _context.Users.FindAsync("600") },


                    }



                });
                _context.Subjects.Add(new Subject
                {
                    Name = "Chemistry",
                    UserSubjects = new List<UserSubject>
                    {
                                        new UserSubject {
                                                           User = await _context.Users.FindAsync("606") },


                    }
                });
                _context.Subjects.Add(new Subject
                {
                    Name = "English"
 
                });
                await _context.SaveChangesAsync();
            }

        }


        private async Task CheckUserSubjectsAsync()
        {
            if (!_context.UserSubjects.Any())
            {
                _context.UserSubjects.Add(new UserSubject
                {

                    
                    User = await _context.Users.FindAsync("788"),
                    Subject = await _context.Subjects.FindAsync(1)

                });
                await _context.SaveChangesAsync();
            }


            //        Assistances = new List<Assistance>
            //            {
            //                new Assistance {
            //                    IsPresent = true,
            //                                   User = await _context.Users.FindAsync("788") },

            //                new Assistance {  IsPresent = true,
            //                                   User = await _context.Users.FindAsync("789") }
            //            }

        }





        private async Task CheckMeetingAsync()
        {
            //public DateTime d = Convert.ToDateTime("27-04-1997");



            //TODO: Before publish en azure put this if statement again
            //if (!_context.Meetings.Any())
            //{
            //if (!_context.Meetings.Any())
            //{

            //    _context.Meetings.Add(new Meeting
            //    {

            //        // Date = Convert.ToDateTime("27-04-2022"),
            //        Date = Convert.ToDateTime("1/1/2020 12:00:00 AM"),

            //        Church = await _context.Churches.FindAsync(6),
            //        Assistances = new List<Assistance>
            //            {
            //                new Assistance {
            //                    IsPresent = true,
            //                                   User = await _context.Users.FindAsync("788") },

            //                new Assistance {  IsPresent = true,
            //                                   User = await _context.Users.FindAsync("789") }
            //            }


            //        //IdChurch = 1
            //        //Church = 1
            //        //Church.Id = 1


            //    }); ;
            //    _context.Meetings.Add(new Meeting
            //    {

            //        //Date = Convert.ToDateTime("27-02-2022"),
            //        Date = Convert.ToDateTime("1/1/1962 12:00:00 AM"),
            //        Church = await _context.Churches.FindAsync(6),

            //        Assistances = new List<Assistance>
            //            {
            //                new Assistance {IsPresent = false,
            //                                   User = await _context.Users.FindAsync("788")},

            //                new Assistance {  IsPresent = false,
            //                                   User = await _context.Users.FindAsync("789") }
            //            }

            //        //IdChurch = 7
            //    });
            //    _context.Meetings.Add(new Meeting
            //    {

            //        Date = Convert.ToDateTime("1/1/1997 12:00:00 AM"),
            //        //Date = Convert.ToDateTime("18-09-2022"),
            //        Church = await _context.Churches.FindAsync(6),

            //        Assistances = new List<Assistance>
            //            {
            //                new Assistance { IsPresent = true,
            //                                   User = await _context.Users.FindAsync("788") },

            //                new Assistance {  IsPresent = false,
            //                                   User = await _context.Users.FindAsync("789") }
            //            }

            //        //IdChurch = 7
            //    });

            //    await _context.SaveChangesAsync();
            //}

            if (!_context.Meetings.Any())
            {

                _context.Meetings.Add(new Meeting
                {

                    // Date = Convert.ToDateTime("27-04-2022"),
                    Date = Convert.ToDateTime("1/1/2020 12:00:00 AM"),

                    Church = await _context.Churches.FindAsync(1),
                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = true,
                                               User = await _context.Users.FindAsync("601") },

                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("602") },
                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("603") },
                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("604") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("605") }
                        }

 


                }); ;
                _context.Meetings.Add(new Meeting
                {

                    //Date = Convert.ToDateTime("27-02-2022"),
                    Date = Convert.ToDateTime("11/10/2020 12:00:00 AM"),
                    Church = await _context.Churches.FindAsync(2),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = true,
                                               User = await _context.Users.FindAsync("607") },

                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("608") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("609") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("610") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("611") }
                        }

                    //IdChurch = 7
                });
                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("1/2/2020 12:00:00 AM"),
                    //Date = Convert.ToDateTime("18-09-2022"),
                    Church = await _context.Churches.FindAsync(4),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = false,
                                               User = await _context.Users.FindAsync("619") },

                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("620") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("621") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("622") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("623") }
                        }

                    //IdChurch = 7
                });
                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("1/1/1997 12:00:00 AM"),
                    //Date = Convert.ToDateTime("18-09-2022"),
                    Church = await _context.Churches.FindAsync(5),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = false,
                                               User = await _context.Users.FindAsync("613") },

                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("614") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("615") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("616") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("617") }
                        }

                    //IdChurch = 7
                });

                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("12/6/2020 12:00:00 AM"),
                    //Date = Convert.ToDateTime("18-09-2022"),
                    Church = await _context.Churches.FindAsync(6),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = true,
                                               User = await _context.Users.FindAsync("625") },

                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("626") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("627") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("628") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("629") }
                        }

                    //IdChurch = 7
                });

                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("12/5/2020 12:00:00 AM"),
                    //Date = Convert.ToDateTime("18-09-2022"),
                    Church = await _context.Churches.FindAsync(7),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = true,
                                               User = await _context.Users.FindAsync("631") },

                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("632") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("633") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("634") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("635") }
                        }

                    //IdChurch = 7
                });
                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("4/4/2019 12:00:00 AM"),
                    //Date = Convert.ToDateTime("18-09-2022"),
                    Church = await _context.Churches.FindAsync(9),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = true,
                                               User = await _context.Users.FindAsync("637") },

                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("638") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("639") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("640") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("641") }
                        }

                    //IdChurch = 7
                });

                _context.Meetings.Add(new Meeting
                {

                    Date = Convert.ToDateTime("4/4/2009 12:00:00 AM"),
                    //Date = Convert.ToDateTime("18-09-2022"),
                    Church = await _context.Churches.FindAsync(10),

                    Assistances = new List<Assistance>
                        {
                            new Assistance {
                                IsPresent = true,
                                               User = await _context.Users.FindAsync("643") },

                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("644") },
                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("645") },
                            new Assistance {  IsPresent = false,
                                               User = await _context.Users.FindAsync("646") },
                            new Assistance {  IsPresent = true,
                                               User = await _context.Users.FindAsync("647") }
                        }

                    //IdChurch = 7
                });
                await _context.SaveChangesAsync();
            }


        }

    


        private async Task CheckAssistanceAsync()
        {
            //public DateTime d = Convert.ToDateTime("27-04-1997");



            //TODO: Before publish en azure put this if statement again
            //if (!_context.Meetings.Any())
            //{

            //String d1 = "5c45e0e1 - d774 - 40fb - 91ab - 5067e7c2e092";
            //_context.Assistances.Add(new Assistance
            //{
            //    IsPresent = false,
            //    User = await _context.Users.FindAsync(10001),
            //    Meeting = await _context.Meetings.FindAsync(9)


            //    //IdChurch = 1
            //    //Church = 1
            //    //Church.Id = 1


            //}) ; 
            //_context.Assistances.Add(new Assistance
            //{


            //    IsPresent = true,
            //    User = await _context.Users.FindAsync(10002),
            //    Meeting = await _context.Meetings.FindAsync(9)

            //    //IdChurch = 7
            //});





            _context.Assistances.Add(new Assistance
            {
                IsPresent = false,
                User = await _context.Users.FindAsync("788"),
                Meeting = await _context.Meetings.FindAsync(9)


                //IdChurch = 1
                //Church = 1
                //Church.Id = 1


            });
            _context.Assistances.Add(new Assistance
            {


                IsPresent = true,
                User = await _context.Users.FindAsync("789"),
                Meeting = await _context.Meetings.FindAsync(9)

                //IdChurch = 7
            });


            await _context.SaveChangesAsync();
            // }

        }


    }
}
