   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   E Adatadesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:datadesign
datadesign 5   	      datadesign.DrMain   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   *localclr-namespace:datadesign     5   	     � Title$  寝室信息��5	   	   $��497.602��6   $��1004.514��6'      AccentColorBrush(   "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5
   	   $��1q�5   	    � WindowStartupLocation$ CenterScreen=�5   	      ShowMaxRestoreButton .  .��5      � -   5         �Name$ progress��5      .+�5   
   �� -   5         ��Name$ label1��5      $��栋号��6    $
��Left=�6-   $��	10,11,0,0q�6H   $	��Top=�6[   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��	70,10,0,0q�6@   $	��Top=�6S   $	��120��6k   5      �� 5   
   -   5        $ label��5      $��	寝室号��6   $
��Left=�6-   $��
220,11,0,0q�6H   $	��Top=�6\   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��0,72,0,0q�6@   $	��Top=�6R   $	��986��6j   $	��394��6v     AzureDataGrid#��[ 6�      
IsReadOnly . ��6�   �� 	 � ContextMenu	 5      �� 5      -   5        $��dgmenu1��5      
 �� 	StaysOpen
 . .@�5      m� -   5        $��增加人员��5      6-   5      5      c� 5   
   -   5         c�Name$ toolBar��5      $
��Left=�6#   $��	10,36,0,0q�6>   $	��Top=�6Q   $��31��6i   $	��420��6u   .@�5      �� -	   5         ��Name$ button1��5      $��栋号查询��6&   $��23��65   $	��Top=�6A   $��75��6Y     AccentedSquareButtonStyle#��[ 6d   6�   �� 5      -
   5        $ button2��5      $��寝室号查询��6&   $��23��66   $	��Top=�6B   $��76��6Z   #��[ 6e   6�   5      �� 5   
   -   5        $ 	comboBox1��5      $
��Left=�6&   $��
280,11,0,0q�6A   $	��Top=�6U   $	��120��6m   �� 5   
   -   5        $ button��5      $��新增/删除寝室��6!   $
��Left=�63   $��	867,0,0,0q�6N   $	��Top=�6a   $	��119��6y   #��[ 6�   $��36��6�   6�   5       5!      