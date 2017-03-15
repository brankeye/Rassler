using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlas.Forms.Interfaces.Pages;
using Atlas.Forms.Interfaces.Services;
using rassler.frontend.core.Domain.Services.Realms;
using rassler.frontend.core.Domain.Utilities;

namespace rassler.frontend.core.Phone.ViewModels.Pages
{
    public class MyClasses : Base.Core, IPageAppearedAware
    {
        public void RefreshData()
        {
            // get classes
            var schoolName = GetUserContext().SchoolName;
            var schoolsRealm = new Domain.Services.Realms.SchoolsRealm();
            var currentSchool = schoolsRealm.Get(x => x.Name == schoolName);
            var classesRealm = new Domain.Services.Realms.ClassesRealm();
            var classes = classesRealm.GetAll(x => x.School == currentSchool).ToList();
            var classesContainer = new List<Domain.Models.Class>();

            var currentDate = SelectedDate;
            for (var i = 0; i < 7; i++)
            {
                // increase current date by one day
                currentDate = currentDate.AddDays(1);

                // loop through all classes
                foreach (var classModel in classes)
                {
                    // if class falls on the current date, add it to the list with the current date
                    if (classModel.DateTime.Day == currentDate.Day)
                    {
                        var classDate = currentDate.UtcDateTime.Date;
                        var canceledClassesRealm = new Domain.Services.Realms.CanceledClassesRealm();
                        var canceledClass = canceledClassesRealm.GetAll(x => x.Class == classModel)
                                            .FirstOrDefault(x => x.Date == classDate);
                        var canceledRecordExists = canceledClass != null;
                        var isCanceled = canceledRecordExists && canceledClass.IsCanceled;
                        classesContainer.Add(classModel);
                    }
                }
            }

            Classes.Clear();
            Classes.AddRange(classesContainer);
        }

        public void OnPageAppeared(IParametersService parameters)
        {
            RefreshData();
        }

        public DateTimeOffset SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; }
        }
        private DateTimeOffset _selectedDate;

        public DynamicCollection<Domain.Models.Class> Classes
        {
            get { return _classes; }
            set { SetProperty(ref _classes, value); }
        }
        private DynamicCollection<Domain.Models.Class> _classes;
    }
}
