   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      '    !Class_Scheduler.Views.ClassesView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Class_Scheduler.Views     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��All Classes��6!   $��32(�64   $��SemiBold"�6B   $��0 20 0 0q�6X   $
��Left=�5      ���#1215186/   �� 5   
   $��0��6      	addButton#��[  6   ��6A   �� *GenerateClassesCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Sync=�6(   $��Center=�64   $��11��6O   $��11��6Z   $��0 1 8 0q�6f   �� 5      $��Generate Class��6   5      5      �� 5    
   $��1��6     
addButton3#��[ 6   $	��130��6f   $	��Top=�6r   $��0 8 0 0q�6�   ��6B   �� *AddClassCommand+.��5!      �� $ 
Horizontal=�6   .+�5"        $
 Plus=�6(   $��Center=�64   $��11��6O   $��11��6Z   $��0 1 8 0q�6f   �� 5#      $��Add New Class��6   5$      5%      �� 5(   
   $��1��6   $ 
Horizontal=�6"   $��0 15 0 0q�6;   .+�5)      �� $��Students��6     tabStaticButton#��[ 6(   5*      �� 5-   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 50   
   $��3��6   $��15(�6"   $��SemiBold"�60   ���#121518$
��Left=�51   )   $��Center=�6D   �� 52      �6   �� *$"RepositoryService.CourseClassCount+ �� 53      $� Total��6   54      �� 56   
   $��	Filter by��6   $��4��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�57   )   $��Center=�6E   &   System.Windows.Controls.DataGrid  5<   
   -   5          Name$ dataGrid��5<        DataGridStyle#���  6%     DataGridCellStyle   	CellStyle# �  6M     DataGridRowStyle   RowStyle# �  6}     DataGridColumnHeaderStyle   ColumnHeaderStyle# �  6�   $��5��6�   ��6�   �� *!RepositoryService.CourseClasses+   Columns 5=      4  .System.Windows.Controls.DataGridCheckBoxColumn  5>      ,  &System.Windows.Controls.DataGridColumn   CanUserResize$ False��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 auto 6?     TableCheckBox1  +System.Windows.Controls.DataGridBoundColumn
   ElementStyle#
 [ 6L      HeaderTemplate 5?      �� 5@      .R�5B      �� 5C      5E      0  *System.Windows.Controls.DataGridTextColumn  5G      -   5        Id��   Header$ #��5G   1   $ False��6<      
IsReadOnly$
 True��6R   $	 50 6d      Binding 6o   �� *Id+4  .System.Windows.Controls.DataGridTemplateColumn  5I      $ 
Class Code��6)   $
 True��6=   $	 * 6O      CellTemplate 5J      �� 5K      .R�5L      �� $ 
Horizontal=�6)   .+�5M   "   �� $��Center=�6G   ��6,   �� *	ClassCode+6G   5N      5O      5Q        5S      $ Subject��6%   $
 True��66   $	 * 6H    6R   �� *	ClassName+  5T      $ Teacher��6%   $
 True��66   $	 * 6H    6R   �� *Teacher.Name+  5U      $ Students��6%   $
 True��67   $	 * 6I    6S   �� *StudentCount+  5X      $ 
Operations��6)   $
 True��6=   $
	 auto 6O    5Y      �� 5Z      .R�5[      �� $ 
Horizontal=�6)   .+�5\   "   �� $	��2.5q�6)     gridEditButton#��[ 66   ��6^   �� * DataContext.ModifyClassCommand+ �� RelativeSource ��  �� AncestorType DataGrid��6�   �� .��5]   &     $ PencilOutline=�6<    	 gridEditButtonIcon#��[	 6Q   5^   #   �� 5_   "   $	��2.5q�6)    
 gridRemoveButton#��[
 66   ��6`   �� * DataContext.DeleteClassCommand+ ��  DataGrid��6�   �� .��5`   &     $ DeleteOutline=�6<   #��[	 6Q   5a   #   5b      5c      5e      5h      �� 5k   
   $��7��6   $��Right=�6   ���#dee4ec$��1q�6P    �� CornerRadius$ 5��5l       �� Padding$ 5q�6"   
�������$��
0 10 10 10q�6A   ._�5m      �� $ 
Horizontal=�6   .+�5n      ��   pagingButton#��[ 6   .��5o        $ ChevronLeft=�6,     pagingButtonIcon#��[ 6?   5p      �� 5r      $��1��6   ���#dee4ec$	��3 7q�65   �� 5s      #��[ 6   $��1��6?   �� 5t      #��[ 6   $��2��6?   ���#7950f2���#ffffff6`   �� 5u      #��[ 6   $��3��6?   �� 5w      #��[ 6   .��5x        $ ChevronRight=�6,   #��[ 6@   5y      5{      5|      5~      5      