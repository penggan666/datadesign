   M S B A M L   `   `   `  ����E  Adatadesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:datadesign
datadesign  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       datadesign.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:datadesign     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  登录��5	   	   $	��350��6   $	��525��6!      AccentColorBrush(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5
      $��1q�5   	    � WindowStartupLocation$ CenterScreen=�5   	      ShowMaxRestoreButton .  .��5      �  J� RenderTransformOrigin$ 0.5,0.5&�6   $��10,0,-0.333,-19.333q�6+    � RowDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ button��5      $��登录��6!   $
��Left=�6.   $��163,212,0,0q�6I   $	��Top=�6^   $	��197��6v   $ 0.489,0.581&�6�   $��16(�6�     AccentedSquareButtonStyle#��[ 6�   �� 5   
   -   5         ��Name$ userid��5      $
��Left=�6"   $��12��6=    �� TextWrapping$
 Wrap=�6I   $	��Top=�6]   $	��197��6u   $��161,102,0,0q�6�   *  $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 请输入账号��6�   
   ClearTextButton
 . 6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $��24��6:   $��118,102,0,0q�6F   $	��Top=�6[   $��29��6s   $ 0.5,0.5&�6~   $��bin/Debug/user.png��6�   $��UniformToFill=�6�   �� 5   
   -   5        $ image1��5      $
��Left=�6    $��24��6;   $��120,146,0,0q�6G   $	��Top=�6\   $��29��6t   $��bin/Debug/lock.png��6   	� 5   
   -   5         	�Name$ radioButton��5      $��宿管人员��6+   $
��Left=�6:   $��223,186,0,0q�6U   $	��Top=�6j   6�   	� 5   
   -   5        $ radioButton1��5      $��	宿管办��6,   $
��Left=�6:   $��300,186,0,0q�6U   $	��Top=�6j   $ 0.407,0.444&�6�   6�   G� 5   
   -   5         G�Name$ passid��5      $
��Left=�6&   $��12��6A   $��163,146,0,0q�6M   $	��Top=�6b   $	��197��6z   $	 请输入密码��6�   
 . 6�   �� 5   
   -   5         ��Name$ label��5      $��    寝室管理系统��6   $
��Left=�64   $��
163,26,0,0q�6O   $	��Top=�6c   $	��195��6{   $��43��6�   $��21.333(�6�   �� 5   
   -	   5        $ label1��5      $��修改密码��6    $��0,288,442,0q�6/   $	��Top=�6D   $��13.333(�6\   $��Right=�6n   $��65��6�   6�   	� 5   
   -
   5        $ radioButton2��5      $��学生��6,   $
��Left=�69   $��167,186,0,0q�6T   $	��Top=�6i   6�   5      5      