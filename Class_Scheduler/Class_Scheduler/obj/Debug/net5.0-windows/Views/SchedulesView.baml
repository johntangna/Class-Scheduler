   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      )    #Class_Scheduler.Views.SchedulesView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      1local#clr-namespace:Class_Scheduler.Views   5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��	Schedules��6!   $��32(�62   $��SemiBold"�6@   $��0 20 0 0q�6V   $
��Left=�5      ���#1215186/   �� 5   
   $��0��6      	addButton#��[  6   ��6A   �� *GenerateScheduleCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Sync=�6(   $��Center=�64   $��11��6O   $��11��6Z   $��0 1 8 0q�6f   �� 5      $��Generate Schedules��6   5      5      �� 5   
   $��1��6     
addButton3#��[ 6   $	��130��6g   $	��Top=�6s   $��0 8 0 0q�6�   ��6B   �� *AddCourseCommand+.��5      �� $ 
Horizontal=�6   .+�5         $
 Plus=�6(   $��Center=�64   $��11��6O   $��11��6Z   $��0 1 8 0q�6f   �� 5!      $��Add New Class��6   5"      5#      �� 5&   
   $��1��6   $ 
Horizontal=�6"   $��0 15 0 0q�6;   .+�5'      �� $��Students��6     tabStaticButton#��[ 6(   5(      �� 5+   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5.   
   $��3��6   ��6   �� *" RepositoryService.Schedule.Slots+��5/      �� 50      .R�51      A�  A� Columns$ 9��6"    A� Rows$ 5��6.   52      ��55      �� 56      .R�57      � .+�58      �� 
������ ��6"   �� *ScheduledClasses+��59      �� 5:   "   .R�5;   &   �� 5<   #   ��5?      �� 5@   "   .R�5A   &   ��  �� CornerRadius$ 10��6-   
�������$��10q�6R   $��25��6^   ._�5B   *   �� $��Center=�6V   $��Center=�6s   $��15(�6�   ��64   �� *Course.ClassCode+6�   5C   '   5D   #   5F      5H      5I      5L      5�      5�      