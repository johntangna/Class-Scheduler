   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Class_Scheduler.ExtensionsClass_Scheduler.Extensions  5   	   $    Class_Scheduler.Views.MainView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   8	extension(clr-namespace:Class_Scheduler.Extensions  5   	   [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5   	   =av2http://schemas.microsoft.com/expression/blend/2008 	 
 5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 
 6G   -   5        ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	   	   $	��980��5
   	   $
��1500��6    � WindowStartupLocation$ CenterScreen=�6#    � WindowStyle$
 None=�6H    � AllowsTransparency$
 True��5   	   
������ *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ SizeChanged��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *NotifySizeChangeCommand+5       � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �� -   5        ���#eff2f7	 �� CornerRadius$	 30��5   "   ._�5   
   � 
 � ColumnDefinitions
 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �  � RowDefinitions 5       �� 5!      $
��auto �6$   �� 5"      $��* �6$   .+�5%      �� $��
20 28 0 35q�6     	topButton#��[ 6-   .��5&      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Menu=�6,   $��15��68   $��15��6C   5'      �� 5)      $��1��6   ���#623ed0$	 	0 50 0 30��6;   ._�5*      ]� $
��True��6    .+�5+      �� $��80��6!   $��80��6,   
�������$		 100��6K   $	��Top=�5,   !   $
��Left=�66   $��
20 -30 0 0q�6Q   ._�5-      A� ��5.   "   �� 5/   &    �� ImageSource$ /Images/user_img.jpg��61   51      52      �� 55      $��Shangde.��6$   
�������$��22(�6G   $��SemiBold"�6U   $	��Top=�56   $    �� TextAlignment$ Center=�69   $��	5 25 0 10q�6P   �� 58      $��Zhiyu Zhang��6$   ���#d0bfff$��14(�6L   $��SemiBold"�6Z   $	��Top=�59   $   $ Center=�69   �� 5<      $��25q�6$   $	��Top=�60   $	��0.8��6E   ���#7e5fdc6R   �� 5A      $	��Top=�6%   .+�5I      	�   
menuButton#��[ 6*   $��SchedulesView��6r   ��6N   �� *NavigateCommand+.��5J   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5K   &     $ CalendarMultiple=�6<     menuButtonIcon#��[ 6T   �� 5L   &   $��	Schedules��60   5M   #   5N      	� 5P      #��[ 6*   $��ClassesView��6r   ��6N   �� *NavigateCommand+.��5Q   "   �� $ 
Horizontal=�6-   .+�5R   &     $ GoogleClassroom=�6<   #��[ 6S   �� 5S   &   $��Classes��60   5T   #   5U      	� 5W      #��[ 6*   $��SubjectsView��6r   ��6N   �� *NavigateCommand+.��5X   "   �� $ 
Horizontal=�6-   .+�5Y   &     $ 	Bookshelf=�6<   #��[ 6M   �� 5Z   &   $��Subjects��60   5[   #   5\      	� 5^      #��[ 6*   $��StudentsView��6r   ��6N   �� *NavigateCommand+.��5_   "   �� $ 
Horizontal=�6-   .+�5`   &     $  AccountMultiplePlusOutline=�6<   #��[ 6^   �� 5a   &   $��Students��60   5b   #   5c      	� 5e      #��[ 6*   $��TeachersView��6r   ��6N   �� *NavigateCommand+.��5f   "   �� $ 
Horizontal=�6-   .+�5g   &     $ HumanMaleBoard=�6<   #��[ 6R   �� 5h   &   $��Teachers��60   5i   #   5j      	� 5l      #��[ 6*   $��ClassroomsView��6r   ��6N   �� *NavigateCommand+.��5m   "   �� $ 
Horizontal=�6-   .+�5n   &     $ MapMarkerOutline=�6<   #��[ 6T   �� 5o   &   $��
Classrooms��60   5p   #   5q      5r      �� 5{      $��Bottom=�6!     menuButton2#��[ 69   .��5|      �� $ 
Horizontal=�6)   .+�5}   "     $ Logout=�68   #��[ 6F   �� 5~   "   $��Logout��6,   5      5�      5�      5�      5�      � 5�      $��1��6   $��30 20 20 20q�6#    5�      �� 5�      $��60 �6$   �� 5�      .+�5�      � $	��300��6   $
��Left=�6#   .+�5�      �� $
��20 0q�6   $��Center=�6,   ���#b0b9c6 J� IsHitTestVisible$ False��6\    K� ZIndex$ 1��5�      $��Search here ...��6/   y�5�      �� *Text+ �� 	Converter# [   �� ElementName$ 	txtSearch���� 5�      -   5         ��Name$ 	txtSearch��5�        textBoxSearch#��[ 61     5�      $ Magnify=�6,   $��15��6;   $��15��6F   $��Center=�6R   $��0 0 15 0q�6m   ���#b0b9c6$��Right=�5�   A   5�      �� 5�      $ 
Horizontal=�6   $��Right=�66   .+�5�      �� #��[ 6   $��0 0 20 0q�6`   $��Right=�6r   ��6@   �� *SaveCommand+.��5�        $ ContentSaveEditOutline=�60   5�      �� 5�      #��[ 6   $��0 0 20 0q�6@   $��Right=�6S   .��5�        $ BellOutline=�60   5�      �� 5�      #��[ 6   $��0 0 20 0q�6c   $��Right=�6u   ��6@   �� *SettingCommand+.��5�        $ 
CogOutline=�60   5�      5�      �� 5�      $��1��6!   -   'Class_Scheduler.Extensions.PrismManager   MainViewRegionName! 
 Prism.Regions.RegionManager   
RegionName# Z 6.   5�      5�      5�      5�      