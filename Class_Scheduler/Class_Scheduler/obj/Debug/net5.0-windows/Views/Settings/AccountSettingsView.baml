   M S B A M L   `   `   `  ����J  FClass_Scheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Class_Scheduler.ViewsClass_Scheduler.Views  5      8    2Class_Scheduler.Views.Settings.AccountSettingsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Class_Scheduler.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $	��120 �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   .+�5      �� $��
My Profile��6   $��SemiBold"�6*   ���#53515c$��0 0 0 5q�6U   �� 5      $	��0.5��6   ���#e2e2e4$��0 7 0 7q�6:   �� 5      $��Preferred name��6   $��14(�6.   $��Medium"�6<   ���#696969$��0 0 0 -3q�6e   �� 5      -   5         ��Name$ studentName��5      $	��260��6J   $
��Left=�6W      textBoxInput#��[  6r    �� AcceptsReturn$
 True��6�    �� TextWrapping$
 Wrap=�6�   ��6+   �� *User.UserName+6�   5      �� 5   
   $��1��6   .+�5      �� $��Account Setting��6   $��SemiBold"�6/   ���#53515c$��0 0 0 5q�6Z   �� 5      $	��0.5��6   ���#e2e2e4$��0 7 0 7q�6:   ]� 5      $��0q�6   $��False��6#   .+�5      �� $
��Left=�6   $��Center=�63   .+�5      �� $��14(�6    $��Email��6.   $��Medium"�6;   ���#53515c$��0 0 0 0q�6d   �� 5      $��12(�6    $��Change the Email Address��6.   $��Regular"�6N   ���#696969$��0 3 0 0q�6x   5      �� 5      -   5        $ email��5   1   $��Right=�6   $	��300��6\   #��[  6h   $
 True��6�   $
 Wrap=�6�   ��6@   �� *
User.Email+6�   5      ]� 5       $��0q�6   $��False��6#   .+�5!      �� $
��Left=�6   $��Center=�63   .+�5"      �� $��14(�6    $��Password��6.   $��Medium"�6>   ���#53515c$��0 0 0 0q�6g   �� 5#      $��12(�6    $��Change the Password��6.   $��Regular"�6I   ���#696969$��0 3 0 0q�6s   5$      �� 5%      -   5        $ password��5%   1   $��Right=�6   $	��300��6b   #��[  6n   $
 True��6�   $
 Wrap=�6�   ��6C   �� *User.Password+6�   5&      ]� 5(      $��0q�6   $��False��6#   .+�5)      �� $
��Left=�6   $��Center=�63   .+�5*      �� $��14(�6    $��School��6.   $��Medium"�6<   ���#53515c$��0 0 0 0q�6e   �� 5+      $��12(�6    $��Change the school��6.   $��Regular"�6G   ���#696969$��0 3 0 0q�6q   5,      �� 5-      $��Right=�6   $	��300��6R   #��[  6^   $
 True��6�   $
 Wrap=�6�   ��61   �� *User.SchoolName+6�   5.      50      52      53      