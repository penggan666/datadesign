   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   E Adatadesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:datadesign
datadesign 5   	      datadesign.Assess   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   *localclr-namespace:datadesign     5   	     � Title$  报修信息��5	   	   $	��300��6   $	��300��6#      AccentColorBrush(   "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5
   	   $��1q�5   	    � WindowStartupLocation$ CenterScreen=�5   	      ShowMaxRestoreButton .  .��5      �  � RowDefinitions 5   
   �� 5      $
��250* �6   �� 5      $	��19* �6   .+�5   
   �� -   5         ��Name$ label��5      $��评价��6   $
��Left=�6,   $��
20,101,0,0q�6G   $	��Top=�6[    J� RenderTransformOrigin$ 0.535,0.102&�6s   �� 5   
   -   5         ��Name$ infoBox��5      $
��Left=�6#   $��88��6>   $��
94,101,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6s   $	��179��6�   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 请输入您的评价��6�   
   ClearTextButton
 . 6�   �� 5   
   -   5         ��Name$ button��5      $��确定��6!   $
��Left=�6.   $��180,209,0,0q�6I   $	��Top=�6^   $��93��6v     AccentedSquareButtonStyle#��[ 6�   6�   �� 5   
   $��修理是否有效��6   $
��Left=�6!   $��	10,45,0,0q�6<   $	��Top=�6O   $ -0.39,-1.141&�6g   �� 5   
   -   5         ��Name$ choice��5      $
��Left=�6%   $��	97,45,0,0q�6@   $	��Top=�6S   $	��120��6k   .@�5      �� .��6   是6   �� 5      .��6   否6   5      5      5      