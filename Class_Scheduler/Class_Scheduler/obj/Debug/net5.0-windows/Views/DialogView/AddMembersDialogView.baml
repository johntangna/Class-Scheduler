   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      0    *Class_Scheduler.Views.AddMembersDialogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      1local#clr-namespace:Class_Scheduler.Views  	 5      _
 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 
 6@   $	��320��5	      $	��450��6,   # 	 Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=�6C   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@�ShowInTaskbar$ False��6.   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   5      .��5      �� ���#EBEAF5._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5       �� $��0��6   $��Add Members��6%   $��25(�68   $��SemiBold"�6F   $��	30 35 0 0q�6\   $
��Left=�5!      ���#12151864   �� 5(      $��1��6   $��8��6&   ���#F9F9FA$��	0 10 0 10q�6F   �� 5*      -   5         ��Name$ textBox��5*      $��2��6'      textBoxSearch#��[  64   $��	15,0,15,0q�6[   $	��130��6n    �� AcceptsReturn$
 True��6{    �� TextWrapping$
 Wrap=�6�   �� 5,      $��3��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��Center=�6\   $��15q�6w   .+�5-      ��   	addButton#��[ 6   $��
0,10,20,10q�6<   ��6P   �� *SubmitCommand+��6r   �� 	 �� ElementName$	 textBox��
 �� Path$

 Text�.��5.      �� $ 
Horizontal=�6!   .+�5/      �� $��Submit��6$   50      51      �� 53      #��[ 6   $��	0,10,0,10q�6<   ��6O   �� *CancelCommand+.��54      �� $ 
Horizontal=�6!   .+�55      �� $��Cancel��6$   56      57      58      59      5:      5;      