   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      (    "Class_Scheduler.Views.TeachersView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Class_Scheduler.Views     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��All Teachers��6!   $��32(�65   $��SemiBold"�6C   $��0 20 0 0q�6Y   $
��Left=�5      ���#1215186/   �� 5   
   $��0��6      	addButton#��[  6   ��6A   �� *AddMemberCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=�6(   $��Center=�64   $��11��6O   $��11��6Z   $��0 1 8 0q�6f   �� 5      $��Add New Member��6   5      5      �� 5    
   $��1��6   $ 
Horizontal=�6"   $��0 15 0 0q�6;   .+�5!      �� $��Teachers��6     tabStaticButton#��[ 6(   5"      �� 5%   
   $��1��6   $��2��6   ���#dae2ea$��	0 -1 0 10q�6A   �� 5(   
   $��3��6   $��15(�6!   $��SemiBold"�6/   ���#121518$
��Left=�5)   )   $��Center=�6D   �� 5*      �6   �� *!RepositoryService.TeachersCount+ �� 5+      $� Total��6   5,      �� 5.   
   $��	Filter by��6   $��3��6%   $��13(�62   $��SemiBold"�6@   $��	0 0 215 0q�6V   ���#121518$��Right=�5/   )   $��Center=�6E   &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ membersDataGrid��54   �     DataGridStyle#���  6     DataGridCellStyle   	CellStyle# �  6;     DataGridRowStyle   RowStyle# �  6k     DataGridColumnHeaderStyle   ColumnHeaderStyle# �  6�   $��5��6�   ��6�   �� *RepositoryService.Teachers+   Columns 55      4  .System.Windows.Controls.DataGridCheckBoxColumn  56      ,  &System.Windows.Controls.DataGridColumn   CanUserResize$ False��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 auto 6?   
   HeaderTemplate
 57      �� 58      .R�59      ��   TableCheckBox#��[ 6'   $��0 0 -3 0q�6N   5:      5<      0  *System.Windows.Controls.DataGridTextColumn  5>         Header$ #��6%   $ False��60      
IsReadOnly$
 True��6F   $	 50 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6c   �� *Id+4  .System.Windows.Controls.DataGridTemplateColumn  5@      $ Member��6)   $
 True��69   $	 * 6K      CellTemplate 5A      �� 5B      .R�5C      �� $ 
Horizontal=�6)   .+�5D   "   �� $��25��6)   $��25��64    �� CornerRadius$ 50��6@   $��0 0 10 0q�6R   
���  ��._�5E   &   �� $��Center=�6K   $��Center=�6f   
�������$��0 0 0 1q�6�   ��60   �� *	Character+6�   5F   #   �� 5H   "   $��Center=�6B   ��6,   �� *Name+6B   5I      5J      5L        5N      $ Subject��6%   $
 True��66   $	 * 6H    6R   �� *
Subjects+  5O      $ Email Address��6%   $
 True��6<   $	 * 6N    6X   �� *EmailAddress+  5Q      $ 
Operations��6)   $
 True��6=   $
	 auto 6O    5R      �� 5S      .R�5T      �� $ 
Horizontal=�6)   .+�5U   "   �� $	��2.5q�6)     gridEditButton#��[ 66   ��6^   �� *!DataContext.ModifyMemberCommand+ �� RelativeSource ��  �� AncestorType DataGrid��6�   �� .��5V   &     $ PencilOutline=�6<     gridEditButtonIcon#��[ 6Q   5W   #   �� 5X   "   $	��2.5q�6)    	 gridRemoveButton#��[	 66   ��6`   �� *!DataContext.DeleteMemberCommand+ ��  DataGrid��6�   �� .��5Y   &     $ DeleteOutline=�6<   #��[ 6Q   5Z   #   5[      5\      5^      5a      �� 5d   
   $��6��6   $��Right=�6   ���#dee4ec$��1q�6P   $ 5��5e       �� Padding$ 5q�6"   
�������$��
0 10 10 10q�6A   ._�5f      �� $ 
Horizontal=�6   .+�5g      ��  
 pagingButton#��[
 6   .��5h        $ ChevronLeft=�6,     pagingButtonIcon#��[ 6?   5i      �� 5k      $��1��6   ���#dee4ec$	��3 7q�65   �� 5l      #��[
 6   $��1��6?   �� 5m      #��[
 6   $��2��6?   ���#7950f2���#ffffff6`   �� 5n      #��[
 6   $��3��6?   �� 5p      #��[
 6   .��5q        $ ChevronRight=�6,   #��[ 6@   5r      5t      5u      5w      5x      