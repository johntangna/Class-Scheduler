   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      (    "Class_Scheduler.Views.SubjectsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Class_Scheduler.Views     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��All Subjects��6!   $��32(�65   $��SemiBold"�6C   $��0 20 0 0q�6Y   $
��Left=�5      ���#1215186/   �� 5   
   $��0��6      	addButton#��[  6   ��6A   �� *AddSubjectCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=�6(   $��Center=�64   $��11��6O   $��11��6Z   $��0 1 8 0q�6f   �� 5      $��Add New Subject��6   5      5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0 15 0 0q�6;   .+�5       �� $��Courses��6     tabStaticButton#��[ 6'   5!      �� 5$   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5(   
   $��3��6   $��15(�6"   $��SemiBold"�60   ���#121518$
��Left=�5)   )   $��Center=�6D   �� 5*      �6   �� *!RepositoryService.SubjectsCount+ �� 5+      $� Total��6   5,      �� 5.   
   $��	Filter by��6   $��3��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�5/   )   $��Center=�6E   &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ dataGrid��54        DataGridStyle#���  6%     DataGridCellStyle   	CellStyle# �  6M     DataGridRowStyle   RowStyle# �  6}     DataGridColumnHeaderStyle   ColumnHeaderStyle# �  6�   $��5��6�   ��6�   �� *RepositoryService.Subjects+   Columns 55      4  .System.Windows.Controls.DataGridCheckBoxColumn  56      ,  &System.Windows.Controls.DataGridColumn   CanUserResize$ False��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 auto 6?   
   HeaderTemplate
 57      �� 58      .R�59      ��   TableCheckBox#��[ 6'   $��0 0 -3 0q�6N   5:      5<      0  *System.Windows.Controls.DataGridTextColumn  5>      -   5        Id��   Header$ #��5>   1   $ False��6<      
IsReadOnly$
 True��6R   $	 50 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6o   �� *Id+4  .System.Windows.Controls.DataGridTemplateColumn  5@      $ Subjects��6)   $
 True��6;   $	 * 6M      CellTemplate 5A      �� 5B      .R�5C      �� $ 
Horizontal=�6)   .+�5D   "   �� $��Center=�6B   ��6,   �� *Name+6B   5E      5F      5H        5J      $ Subject Group��6%   $
 True��6<   $	 * 6N    6X   �� *SubjectGroup+  5K      $ Numbers Per Week��6%   $
 True��6?   $	 * 6Q    6[   �� *CountPerWeek+  5L      $ Teacher��6%   $
 True��66   $	 * 6H    6R   �� *TeacherNames+  5N      $ 
Operations��6)   $
 True��6=   $
	 auto 6O    5O      �� 5P      .R�5Q      �� $ 
Horizontal=�6)   .+�5R   "   �� $	��2.5q�6)     gridEditButton#��[ 66   ��6^   �� *" DataContext.ModifySubjectCommand+ �� RelativeSource ��  �� AncestorType DataGrid��6�   �� .��5S   &     $ PencilOutline=�6<     gridEditButtonIcon#��[ 6Q   5T   #   �� 5U   "   $	��2.5q�6)    	 gridRemoveButton#��[	 66   ��6`   �� *" DataContext.DeleteSubjectCommand+ ��  DataGrid��6�   �� .��5V   &     $ DeleteOutline=�6<   #��[ 6Q   5W   #   5X      5Y      5[      5^      �� 5a   
   $��6��6   $��Right=�6   ���#dee4ec$��1q�6P    �� CornerRadius$ 5��5b       �� Padding$ 5q�6"   
�������$��
0 10 10 10q�6A   ._�5c      �� $ 
Horizontal=�6   .+�5d      ��  
 pagingButton#��[
 6   .��5e        $ ChevronLeft=�6,     pagingButtonIcon#��[ 6?   5f      �� 5h      $��1��6   ���#dee4ec$	��3 7q�65   �� 5i      #��[
 6   $��1��6?   �� 5j      #��[
 6   $��2��6?   ���#7950f2���#ffffff6`   �� 5k      #��[
 6   $��3��6?   �� 5m      #��[
 6   .��5n        $ ChevronRight=�6,   #��[ 6@   5o      5q      5r      5t      5u      