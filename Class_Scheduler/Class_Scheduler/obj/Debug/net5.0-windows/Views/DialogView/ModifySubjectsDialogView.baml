   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      4    .Class_Scheduler.Views.ModifySubjectsDialogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      1local#clr-namespace:Class_Scheduler.Views  	 5      _
 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 
 6@   $	��450��5	      $	��350��6,   # 	 Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=�6C   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@�ShowInTaskbar$ False��6.   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   5      .��5      �� ���#EBEAF5._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5!      �� $��0��6   $��25(�6%   $��SemiBold"�63   $��	30 35 0 0q�6I   $
��Left=�5"      ���#121518�� 6J   $
�Edit��6N   �� 6\   $� ��6`   �� 6k    � Language$ zh-cn�6o   $�Subject��6�   6�   �� 5)      $��1��6   $��8��6&   ���#F9F9FA$��	0 10 0 10q�6F   �� 5+      $��2��6    �� Orientation$ Vertical=�6&   $��	30,0,30,0q�6=   .+�5,      �� $��Medium"�6   ���#696969$��0 0 0 -3q�6E   �� 6X   $ zh-cn�6\   $�Subject��6m   �� 6~   $� Name:��6�   6�   �� 5-      -   5         ��Name$ 
courseName��5-         textBoxInput#��[  6P    �� AcceptsReturn$
 True��6v   	 �� TextWrapping$
	 Wrap=�6�   ��6.   �� *InputLesson.Name+6�   �� 5.      $��Teacher:��6   $��Medium"�6,   ���#696969$��0 0 0 -3q�6U   �� 5/      -   5        $ teacherName��5/      #��[  6X   $
 True��6~   $
	 Wrap=�6�   ��6/   �� *InputLesson.TeacherName+6�   �� 50      $��Subject Group:��6   $��Medium"�62   ���#696969$��0 0 0 0q�6[   �� 51      -   5        
 ��Name$
 subjectGroup��51      $	��175��6d     ComboBoxFlatStyle#��[ 6p   $
��Left=�6�   $��25��6�   $��0 4 0 0q�6�    �� SelectedValue 61   �� *InputLesson.SubjectGroup+��6�   �� *subjectGroup+6�   �� 52      $��Number Per Week:��6   $��Medium"�64   ���#696969$��0 10 0 0q�6]   �� 53      -   5        $
 countPerWeek��53      $��50��6d   #��[ 6o   $
��Left=�6�   $��25��6�   $��0 4 0 0q�6�    61   �� *InputLesson.CountPerWeek+��6�   �� *
numPerWeek+6�   54      �� 56      $��3��6   $��8��6&   ���#F9F9FA$��	0 10 0 10q�6F   �� 58      $��4��6   $ 
Horizontal=�6&   $��Center=�6?   $	��Top=�6\   .+�59      ��   	addButton#��[ 6   $��	10 0 0 15q�6<   ��6O   �� *SubmitCommand+.��5:      �� $ 
Horizontal=�6!   .+�5;      �� $
��Edit��6$   5<      5=      �� 5?      #��[ 6   $��
10 0 10 15q�6<   $	��140��6r   ��6P   �� *CancelCommand+.��5@      �� $ 
Horizontal=�6!   .+�5A      �� $��Cancel��6$   5B      5C      5D      5E      5F      5G      