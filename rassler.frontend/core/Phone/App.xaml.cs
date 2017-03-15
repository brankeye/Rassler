using System;
using System.Collections.Generic;
using System.Linq;
using Atlas.Forms;
using Atlas.Forms.Interfaces;
using Atlas.Forms.Services;
using Newtonsoft.Json;
using rassler.frontend.core.Domain.Models;
using rassler.frontend.core.Domain.Objects;
using rassler.frontend.core.Domain.Services.Cache;
using rassler.frontend.core.Domain.Services.Realms;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace rassler.frontend.core.Phone
{
    public partial class App : AtlasApplication
    {
        public App()
        {
            InitializeComponent();
            LoadUserContext();
        }

        protected override void RegisterPagesForNavigation(IPageNavigationRegistry registry)
        {
            registry.RegisterPage<NavigationPage>();
            registry.RegisterPage<Views.Pages.Login, ViewModels.Pages.Login>();
            registry.RegisterPage<Views.Pages.Dashboard, ViewModels.Pages.Dashboard>();
            registry.RegisterPage<Views.Pages.Details.Profile, ViewModels.Pages.Details.Profile>();
            registry.RegisterPage<Views.Pages.MyClasses, ViewModels.Pages.MyClasses>();
            registry.RegisterPage<Views.Pages.Schedule, ViewModels.Pages.Schedule>();
        }

        protected override void RegisterPagesForCaching(IPageCacheRegistry registry)
        {

        }

        protected void LaunchLoginPage()
        {
            NavigationService.SetMainPage(Nav.Get<Views.Pages.Login>().AsNavigationPage().Info());
        }

        protected void LaunchDashboardPage()
        {
            NavigationService.SetMainPage(Nav.Get<Views.Pages.Dashboard>().Info());
        }

        protected void LoadUserContext()
        {
            object contextObject;
            Current.Properties.TryGetValue("Context", out contextObject);
            UserContext userContext = null;
            if (contextObject != null)
            {
                userContext = JsonConvert.DeserializeObject<UserContext>((string)contextObject);
            }
            userContext = userContext ?? new UserContext();
            userContext.SchoolName = "STVTO";
            UserContextCache.Current.Replace("Context", userContext);
        }

        protected void SaveUserContext()
        {
            var userContext = UserContextCache.Current.Get("Context");
            Current.Properties["Context"] = JsonConvert.SerializeObject(userContext);
        }

        protected void LoadDummyData()
        {
            var instance = Realm.GetInstance();
            instance.Write(() => instance.RemoveAll());

            var standingsRealm = new Domain.Services.Realms.StandingsRealm();
            standingsRealm.Write(() =>
            {
                var standings = new List<Domain.Models.Standing>()
                {
                    new Standing() {
                        Title = "HeadInstructor",
                        Level = 1
                    },
                    new Standing() {
                        Title = "Instructor",
                        Level = 2
                    },
                    new Standing() {
                        Title = "Student",
                        Level = 3
                    }
                };
                standingsRealm.AddAll(standings.AsQueryable());
            });

            var usersRealm = new Domain.Services.Realms.UsersRealm();
            usersRealm.Write(() =>
            {
                var user = new Domain.Models.User()
                {
                    Username = "jd@gmail.com"
                };
                usersRealm.Add(user);
            });

            var schoolsRealm = new Domain.Services.Realms.SchoolsRealm();
            schoolsRealm.Write(() =>
            {
                var school = new Domain.Models.School()
                {
                    Name = "STVTO"
                };
                schoolsRealm.Add(school);
            });

            var profilesRealm = new Domain.Services.Realms.ProfilesRealm();
            profilesRealm.Write(() =>
            {
                var currentUser = usersRealm.Get(x => x.Username == "jd@gmail.com");
                var profiles = new List<Domain.Models.Profile>()
                {
                    new Profile()
                    {
                        ContactInfo = new ContactInfo()
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            Email = "jd@gmail.com",
                            PhoneNumber = "613456789"
                        },
                        IsActive = true,
                    },
                    new Profile()
                    {
                        ContactInfo = new ContactInfo()
                        {
                            FirstName = "Krit",
                            LastName = "Mangy",
                            Email = "kmangy@gmail.com",
                            PhoneNumber = "613456789"
                        },
                        IsActive = true,
                    },
                    new Profile()
                    {
                        ContactInfo = new ContactInfo()
                        {
                            FirstName = "Harriet",
                            LastName = "Doe",
                            Email = "harrietisallthat@gmail.com",
                            PhoneNumber = "613456789"
                        },
                        IsActive = true,
                    },
                    new Profile()
                    {
                        ContactInfo = new ContactInfo()
                        {
                            FirstName = "Marge",
                            LastName = "Doe",
                            Email = "marge@gmail.com",
                            PhoneNumber = "613456789"
                        },
                        IsActive = false,
                    }
                };
                var profilesAdded = profilesRealm.AddAll(profiles.AsQueryable());
                var currentProfile = profilesAdded.FirstOrDefault();
                currentProfile.User = currentUser;
                var currentSchool = schoolsRealm.Get(x => x.Name == "STVTO");
                foreach (var profile in profilesAdded)
                {
                    profile.School = currentSchool;
                }
            });

            var contactInfosRealm = new ContactInfosRealm();
            var ranksRealm = new Domain.Services.Realms.RanksRealm();
            ranksRealm.Write(() =>
            {
                var rank = new Rank()
                {
                    Name = "Red",
                    Level = 1,
                    AchievementDate = DateTimeOffset.Now
                };
                var rank1 = ranksRealm.Add(rank);
                var contactInfo1 = contactInfosRealm.Get(x => x.FirstName == "John");
                rank1.Profile = profilesRealm.Get(x => x.ContactInfo == contactInfo1);

                rank = new Rank()
                {
                    Name = "Green",
                    Level = 2,
                    AchievementDate = DateTimeOffset.Now
                };
                var rank2 = ranksRealm.Add(rank);
                var contactInfo2 = contactInfosRealm.Get(x => x.FirstName == "Krit");
                rank2.Profile = profilesRealm.Get(x => x.ContactInfo == contactInfo2);

                rank = new Rank()
                {
                    Name = "Blue",
                    Level = 3,
                    AchievementDate = DateTimeOffset.Now
                };
                var rank3 = ranksRealm.Add(rank);
                var contactInfo3 = contactInfosRealm.Get(x => x.FirstName == "Krit");
                rank3.Profile = profilesRealm.Get(x => x.ContactInfo == contactInfo3);
            });

            var classesRealm = new Domain.Services.Realms.ClassesRealm();
            classesRealm.Write(() =>
            {
                var classes = new List<Domain.Models.Class>()
                {
                    new Class()
                    {
                        Name = "Beginner 1",
                        DateTime = DateTimeOffset.Now,
                        Minutes = 120,
                    },
                    new Class()
                    {
                        Name = "Beginner 2",
                        DateTime = DateTimeOffset.Now,
                        Minutes = 120,
                    },
                    new Class()
                    {
                        Name = "Beginner 3",
                        DateTime = DateTimeOffset.Now,
                        Minutes = 120,
                    },
                    new Class()
                    {
                        Name = "Intermediate 1",
                        DateTime = DateTimeOffset.Now,
                        Minutes = 120,
                    },
                    new Class()
                    {
                        Name = "Intermediate 2",
                        DateTime = DateTimeOffset.Now,
                        Minutes = 120,
                    },
                    new Class()
                    {
                        Name = "Advanced 1",
                        DateTime = DateTimeOffset.Now,
                        Minutes = 120,
                    },
                    new Class()
                    {
                        Name = "Advanced 2",
                        DateTime = DateTimeOffset.Now,
                        Minutes = 120,
                    }
                };

                var school = schoolsRealm.Get(x => x.Name == "STVTO");
                var classesAdded = classesRealm.AddOrUpdateAll(classes.AsQueryable());
                foreach (var item in classesAdded)
                {
                    item.School = school;
                }
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            LoadDummyData();

            var userContext = UserContextCache.Current.Get("Context");
            if (userContext != null && userContext.IsAuthenticated)
            {
                LaunchDashboardPage();
            }
            else
            {
                LaunchLoginPage();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            SaveUserContext();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
