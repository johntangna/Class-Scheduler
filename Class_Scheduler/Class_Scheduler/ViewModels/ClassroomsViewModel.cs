using Class_Scheduler.Common.Models;
using Class_Scheduler.Extensions;
using Class_Scheduler.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.ViewModels
{
    public class ClassroomsViewModel : BindableBase
    {
        private readonly IDialogService dialogService;
        private readonly IRepositoryService repositoryService;

        private int roomCount;
        private int CumulativeRoomCount;

        public int RoomCount
        {
            get { return roomCount; }
            set { roomCount = value; RaisePropertyChanged(); }
        }

        public IRepositoryService RepositoryService { get { return repositoryService; } }

        public DelegateCommand AddRoomCommand { get; private set; }

        public DelegateCommand<Room> ModifyRoomCommand { get; private set; }

        public DelegateCommand<Room> DeleteRoomCommand { get; private set; }

        public ClassroomsViewModel(IDialogService dialogService, IRepositoryService repositoryService) 
        {
            this.dialogService = dialogService;
            this.repositoryService = repositoryService;

            AddRoomCommand = new DelegateCommand(AddRoom);
            ModifyRoomCommand = new DelegateCommand<Room>(EditRoom);
            DeleteRoomCommand = new DelegateCommand<Room>(DeleteRoom);

            roomCount = repositoryService.Rooms.Count;      
        }
       
        private void AddRoom()
        {
            dialogService.ShowDialog(PrismManager.AddRoomDialogName, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    var room = callback.Parameters.GetValue<Room>("Room");
                    room.Id = CumulativeRoomCount;
                    repositoryService.Rooms.Add(room);
                    RoomCount++;
                    CumulativeRoomCount++;
                }
            });
        }

        private void DeleteRoom(Room room)
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("ShownData", "Are you sure you want to delete this room?\r\n");
            dialogService.ShowDialog(PrismManager.DeleteMemberDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    // Delete Members
                    if (!repositoryService.Rooms.Remove(room))
                    {
                        // 日志输出
                    }
                    else
                    {
                        RoomCount--;
                    }
                }
            });
        }

        private void EditRoom(Room room)
        {
            DialogParameters keys = new DialogParameters
            {
                { "Room", room }
            };
            dialogService.ShowDialog(PrismManager.ModifyRoomDialogName, keys, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    var tmp = callback.Parameters.GetValue<Room>("Room");

                    repositoryService.Rooms[room.Id] = tmp;
                }
            });
        }
    }
}
