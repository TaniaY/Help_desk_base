using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class DbInitializer
    {
        public static User[] users;
        public static Group[] groups;
        public static void Initialize(ApplicationContext context)
        {

            if (!context.Users.Any())
            {
                users = new User[]
               {
                    new User{Fname="Yan", Lname="Kolovorotny", Login="Somelog", Email="yankolovorotny@gmail.com", Phone="somephone"},

               };
                foreach (User us in users)
                {
                    context.Users.Add(us);
                }
                context.SaveChanges();
            }
            if (!context.Groups.Any())
            {
                groups = new Group[]
             {
                 new Group { Name = "Супер Администратор",  Slug = Helpers.SlugGenerator.GenerateSlug("Супер Администратор")  },
                 new Group { Name = "Администратор",  Slug = Helpers.SlugGenerator.GenerateSlug("Администратор")  },
                 new Group { Name = "Администратор предприятия",  Slug = Helpers.SlugGenerator.GenerateSlug("Администратор предприятия")  },
                 new Group { Name = "Администратор структурного подразделения",  Slug = Helpers.SlugGenerator.GenerateSlug("Администратор структурного подразделения")  },
                 new Group { Name = "Пользователь",  Slug = Helpers.SlugGenerator.GenerateSlug("Пользователь")  },
                 new Group { Name = "Исполнитель",  Slug = Helpers.SlugGenerator.GenerateSlug("Исполнитель")  },

             };
                foreach (Group s1 in groups)
                {
                    context.Groups.Add(s1);
                }
                context.SaveChanges();
            }

            if (!context.UsersGroups.Any())
            {

                groups[0].UsersGroups.Add(new UsersGroup { GroupId = groups[0].Id, UserId = users[0].Id });
                context.SaveChanges();

            }
        }
    }

}