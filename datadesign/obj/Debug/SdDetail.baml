   M S B A M L   `   `   `  ����E  Adatadesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:datadesign
datadesign  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       datadesign.SdDetail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:datadesign     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  学生住宿情况��5	   	   $��497.602��6   $��1004.514��6)      AccentColorBrush(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5
   	   $��1q�5   	    � WindowStartupLocation$ CenterScreen=�5   	      ShowMaxRestoreButton .  .��5      � .+�5   
   c� -   5         c�Name$ toolBar��5      $
��Left=�6#   $��0,41,0,0q�6>   $	��Top=�6P   $	��630��6h   .@�5      �� -   5         ��Name$ button��5      $��学号查询��6%   $��23��64   $��81��6@   $��0,0,0,0.333q�6K     AccentedSquareButtonStyle#��[ 6u   �� 5      -   5        $ button1��5      $��学院查询��6&   $��23��65   $	��Top=�6A   $��81��6Y   #��[ 6d   6�   �� 5      -   5        $ button2��5      $��栋号查询��6&   $��23��65   $��Bottom=�6A   $��81��6\   #��[ 6g   6�   �� 5      -   5        $ button3��5      $��寝室号查询��6&   $��23��66   $	��Top=�6B   $��81��6Z   #��[ 6e   6�   �� 5      -   5        $ button4��5      $��入住时间查询��6&   $��23��67   $	��Top=�6C   $��81��6[   #��[ 6f   6�   �� 5      -   5        $ button5��5      $��安排新生入住��6&   $��23��67   $	��Top=�6C   $��81��6[   #��[ 6f   6�   �� 5      -   5        $ button6��5      $��毕业学生离校��6&   $��23��67   $��Stretch=�6C   $��81��6_   #��[ 6j   $��0,0,0,0.333q�6�   5      �� 5   
   -	   5         ��Name$ label��5      $��学号��6   $
��Left=�6,   $��	10,10,0,0q�6G   $	��Top=�6Z   �� 5   
   -
   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>   $��	50,10,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6r   $	��120��6�   *  $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 请输入学号��6�   
   ClearTextButton
 . 6�   �� 5   
   -   5        $ label2��5      $��	寝室号��6    $
��Left=�6.   $��
520,10,0,0q�6I   $	��Top=�6]   �� 5   
   -   5        $ label1��5      $��学院��6    $
��Left=�6-   $��
180,10,0,0q�6H   $	��Top=�6\   �� 5   
   -   5        $ label3��5      $��入住时间��6    $
��Left=�6/   $��
700,10,0,0q�6J   $	��Top=�6^   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��	10,72,0,0q�6@   $	��Top=�6S   $	��986��6k   $	��394��6w     AzureDataGrid#��[ 6�      
IsReadOnly . ��6�   ��  � ContextMenu 5      �� 5       -   5        $��dgmenu1��5        �� 	StaysOpen . .@�5!      m� -   5        $��删除��5!      6+   5"      5$      �� 5%   
   -   5        $ label4��5%      $��栋号��6    $
��Left=�6-   $��
350,11,0,0q�6H   $	��Top=�6\   �� 5&   
   -   5         ��Name$ 	textBlock��5&      $
��Left=�6'   $��0��6B   $��
558,26,0,0q�6M   $
��Wrap=�6a   $��	TextBlock��6u   $	��Top=�6�   $��8��6�   �� 5'   
   -   5         ��Name$ comboBox��5'      $
��Left=�6%   $��
390,10,0,0q�6@   $	��Top=�6T   $	��120��6l   5(      �� 5)   
   -   5        $ 	comboBox1��5)      $
��Left=�6&   $��	220,9,0,0q�6A   $	��Top=�6T   $	��120��6l   �� 5*   
   -   5        $ 	comboBox2��5*      $
��Left=�6&   $��
763,11,0,0q�6A   $	��Top=�6U   $	��120��6m   �� 5+   
   -   5        $ 	comboBox3��5+      $
��Left=�6&   $��
571,12,0,0q�6A   $	��Top=�6U   $	��120��6m   5.      5/      