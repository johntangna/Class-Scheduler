   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      (    "Class_Scheduler.Views.StudentsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Class_Scheduler.Views     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��All Students��6!   $��32(�65   $��SemiBold"�6C   $��0 20 0 0q�6Y   $
��Left=�5      ���#1215186/   �� 5   
   $��0��6      	addButton#��[  6   ��6A   �� *AddStudentCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=�6(   $��Center=�64   $��11��6O   $��11��6Z   $��0 1 8 0q�6f   �� 5      $��Add New Member��6   5      5      �� 5!   
   $��1��6   $ 
Horizontal=�6"   $��0 15 0 0q�6;   .+�5"      �� $��Students��6     tabStaticButton#��[ 6(   5#      �� 5&   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5)   
   $��3��6   $��15(�6"   $��SemiBold"�60   ���#121518$
��Left=�5*   )   $��Center=�6D   �� 5+      �6   �� *!RepositoryService.StudentsCount+ �� 5,      $� Total��6   5-      �� 5/   
   $��	Filter by��6   $��3��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�50   )   $��Center=�6E   &   System.Windows.Controls.DataGrid  55   
   -   5          Name$ dataGrid��55        DataGridStyle#���  6%     DataGridCellStyle   	CellStyle# �  6M     DataGridRowStyle   RowStyle# �  6}     DataGridColumnHeaderStyle   ColumnHeaderStyle# �  6�   $��5��6�   ��6�   �� *RepositoryService.Students+   Columns 56      4  .System.Windows.Controls.DataGridCheckBoxColumn  57      ,  &System.Windows.Controls.DataGridColumn   CanUserResize$ False��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 auto 6?     TableCheckBox1  +System.Windows.Controls.DataGridBoundColumn
   ElementStyle#
 [ 6L      HeaderTemplate 58      �� 59      .R�5;      �� 5<      5>      0  *System.Windows.Controls.DataGridTextColumn  5@      -   5        Id��   Header$ #��5@   1   $ False��6<      
IsReadOnly$
 True��6R   $	 50 6d      Binding 6o   �� *Id+4  .System.Windows.Controls.DataGridTemplateColumn  5B      $ Member��6)   $
 True��69   $	 * 6K      CellTemplate 5C      �� 5D      .R�5E      �� $ 
Horizontal=�6)   .+�5F   "   �� $��25��6)   $��25��64    �� CornerRadius$ 50��6@   $��0 0 10 0q�6R   
���  ��._�5G   &   �� $��Center=�6K   $��Center=�6f   
�������$��0 0 0 1q�6�   ��60   �� *	Character+6�   5H   #   �� 5J   "   $��Center=�6B   ��6,   �� *Name+6B   5K      5L      5N        5P      $ Class��6%   $
 True��64   $	 * 6F    6P   �� *GradeAndClass+  5Q      $	 Sex��6%   $
 True��62   $	 * 6D    6N   �� *Sex+  5R      $ Email Address��6%   $
 True��6<   $	 * 6N    6X   �� *EmailAddress+  5S      $ Courses��6)   $
 True��6:   $	 90 6L    5T      �� 5U      .R�5V        $ InformationOutline=�64   $��20��6N   5W      5Y        5[      $ 
Operations��6)   $
 True��6=   $
	 auto 6O    5\      �� 5]      .R�5^      �� $ 
Horizontal=�6)   .+�5_   "   �� $	��2.5q�6)     gridEditButton#��[ 66   ��6^   �� *!DataContext.ModifyMemberCommand+ �� RelativeSource ��  �� AncestorType DataGrid��6�   �� .��5`   &     $ PencilOutline=�6<     gridEditButtonIcon#��[ 6Q   5a   #   �� 5b   "   $	��2.5q�6)    	 gridRemoveButton#��[	 66   ��6`   �� *!DataContext.DeleteMemberCommand+ ��  DataGrid��6�   �� .��5c   &     $ DeleteOutline=�6<   #��[ 6Q   5d   #   5e      5f      5h      5k      �� 5n   
   $��6��6   $��Right=�6   ���#dee4ec$��1q�6P   $ 5��5o       �� Padding$ 5q�6"   
�������$��
0 10 10 10q�6A   ._�5p      �� $ 
Horizontal=�6   .+�5q      ��  
 pagingButton#��[
 6   .��5r        $ ChevronLeft=�6,     pagingButtonIcon#��[ 6?   5s      �� 5u      $��1��6   ���#dee4ec$	��3 7q�65   �� 5v      #��[
 6   $��1��6?   �� 5w      #��[
 6   $��2��6?   ���#7950f2���#ffffff6`   �� 5x      #��[
 6   $��3��6?   �� 5z      #��[
 6   .��5{        $ ChevronRight=�6,   #��[ 6@   5|      5~      5      5�      5�      