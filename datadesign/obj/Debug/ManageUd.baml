   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   E Adatadesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:datadesign
datadesign 5   	      datadesign.ManageUd   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   *localclr-namespace:datadesign     5   	     � Title$  管理人员信息��5	   	   $��491.255��6   $��733.867��6)      AccentColorBrush(   "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5
   	   $��1q�5   	    � WindowStartupLocation$ CenterScreen=�5   	      ShowMaxRestoreButton .  .��5      � .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��100��6T   $��288,733,0,-373q�6a   $	��Top=�6y   $	��100��6�   �� 5   
   -   5         ��Name$ label��5      $��工号��6   $
��Left=�6,   $��	10,10,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5         ��Name$ button��5      $��按工号查询��6!   $
��Left=�61   $��	437,7,0,0q�6L   $	��Top=�6_   $��75��6w     AccentedSquareButtonStyle#��[ 6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��0,43,0,0q�6@   $	��Top=�6R   $	��715��6j   $	��417��6v      
IsReadOnly .  � ContextMenu 5      �� 5      -   5        $��dgmenu1��5      	 �� 	StaysOpen	 . .@�5      m� -   5        $��新增��5      6+   m� 5      -   5        $��修改��5      6+   m� 5      -   5        $��删除��5      6+   5      5      �� 5   
   -   5        $ button_Copy��5      $��栋号查询��6&   $
��Left=�65   $��	555,7,0,0q�6P   $	��Top=�6c   $��82��6{   #��[ 6�   
 J� RenderTransformOrigin$
 0.368,0.157&�6�   �� 5   
   $��栋号��6   $
��Left=�6   $��
213,10,0,0q�68   $	��Top=�6L   �� 5   
   -	   5         ��Name$ comboBox��5      $
��Left=�6%   $��	64,10,0,0q�6@   $	��Top=�6S   $	��120��6k   �� 5   
   -
   5        $ 	comboBox1��5      $
��Left=�6&   $��
268,11,0,0q�6A   $	��Top=�6U   $	��120��6m   5      5       