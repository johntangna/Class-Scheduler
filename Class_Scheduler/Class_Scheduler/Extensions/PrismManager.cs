using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Extensions
{
    public static class PrismManager
    {
        public static readonly string MainViewRegionName = "MainViewRegion";
        public static readonly string SettingViewRegionName = "SettingViewRegion";

        public static readonly string MemberViewRegionName = "MemberViewRegion";
        public static readonly string DeleteMemberDialogName = "DeleteMembersDialogView";
        public static readonly string ModifyStudentDialogName = "ModifyStudentsDialogView";
        public static readonly string ModifyTeacherDialogName = "ModifyTeachersDialogView";
        public static readonly string AddSubjectDialogName = "AddSubjectsDialogView";
        public static readonly string ModifySubjectsDialogName = "ModifySubjectsDialogView";
        public static readonly string AddRoomDialogName = "AddRoomsDialogView";
        public static readonly string ModifyRoomDialogName = "ModifyRoomsDialogView";
        public static readonly string AddStudentsDialogName = "AddStudentsDialogView";
        public static readonly string SettingsDialogName = "SettingView";
        public static readonly string AddTeachersDialogName = "AddTeachersDialogView";

        public static readonly string SavedPath = "./Save.xml";
        public static readonly string UserSettingSavedPath = "./UserSetting.xml";
    }
}
