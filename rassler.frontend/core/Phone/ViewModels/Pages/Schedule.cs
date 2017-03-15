using System;
using System.Collections.Generic;
using System.Linq;
using Atlas.Forms.Interfaces.Pages;
using Atlas.Forms.Interfaces.Services;
using rassler.frontend.core.Domain.Models;
using rassler.frontend.core.Domain.Services.Realms;
using rassler.frontend.core.Domain.Utilities;

namespace rassler.frontend.core.Phone.ViewModels.Pages
{
    public class Schedule : Base.Core, IPageAppearedAware
    {
        public Schedule()
        {
            Classes = new DynamicCollection<Class>();
        }

        public void RefreshData()
        {
            var schoolName = GetUserContext().SchoolName;
            var schoolsRealm = new SchoolsRealm();
            var currentSchool = schoolsRealm.Get(x => x.Name == schoolName);
            var classesRealm = new ClassesRealm();
            var classes = classesRealm.GetAll(x => x.School == currentSchool).ToList();
            var classesContainer = new List<Class>();
            foreach (var entity in classes)
            {
                classesContainer.Add(entity);
            }
            Classes.Clear();
            Classes.AddRange(classesContainer);
        }

        public void OnPageAppeared(IParametersService parameters)
        {
            RefreshData();
        }

        public DynamicCollection<Class> Classes
        {
            get { return _classes; }
            set { SetProperty(ref _classes, value); }
        }
        private DynamicCollection<Class> _classes;
    }
}
