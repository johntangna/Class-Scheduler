   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      .    (Class_Scheduler.Views.AddRoomsDialogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      1local#clr-namespace:Class_Scheduler.Views  	 5      _
 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 
 6@   $	��330��5	      $	��350��6,   # 	 Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=�6C   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@�ShowInTaskbar$ False��6.   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   5      .��5      �� ���#EBEAF5._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5!      �� $��0��6   $��25(�6%   $��SemiBold"�63   $��	30 35 0 0q�6I   $
��Left=�5"      ���#121518�� 6J   $
�Add ��6N   �� 6\    � Language$ zh-cn�6`   $
�Room��6q   6�   �� 5)      $��1��6   $��8��6&   ���#F9F9FA$��	0 10 0 10q�6F   �� 5+      $��2��6    �� Orientation$ Vertical=�6&   $��	30,0,30,0q�6=   .+�5,      �� $��Medium"�6   ���#696969$��0 0 0 -3q�6E   �� 6X   $ zh-cn�6\   $
�Room��6m   �� 6{   $� Name:��6   6�   �� 5-      -   5         ��Name$ 
courseName��5-         textBoxInput#��[  6I    �� AcceptsReturn$
 True��6o   	 �� TextWrapping$
	 Wrap=�6�   ��6.   �� *	Room.Name+6�   �� 5.      $��Using Purpose:��6   $��Medium"�62   ���#696969$��0 0 0 0q�6[   �� 5/      -   5        
 ��Name$	
 sex��5/      $	��175��6O     ComboBoxFlatStyle#��[ 6[   $
��Left=�6�   $��25��6�   $��0 4 0 0q�6�    �� SelectedValue 6(   �� *Room.Purpose+��6�   �� *usingPurpose+6�   50      �� 52      $��3��6   $��8��6&   ���#F9F9FA$��	0 10 0 10q�6F   �� 54      $��4��6   $ 
Horizontal=�6&   $��Center=�6?   $	��Top=�6\   .+�55      ��   	addButton#��[ 6   $��	10 0 0 15q�6<   ��6O   �� *SubmitCommand+.��56      �� $ 
Horizontal=�6!   .+�57      �� $	��Add��6$   58      59      �� 5;      #��[ 6   $��
10 0 10 15q�6<   $	��140��6r   ��6P   �� *CancelCommand+.��5<      �� $ 
Horizontal=�6!   .+�5=      �� $��Cancel��6$   5>      5?      5@      5A      5B      5C      