   M S B A M L   `   `   `  ����  WpfApplication1     WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AutoRepairs��5   	   $	��460��6   $	��620��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   .+�5   
   �� -   5         ��Name$ Button_Load��5      $��0��6   $
��Load��64   $
��Left=�6C   $	��Top=�6^   $��82��6v   $��10,9,0,0q�6�   $��21��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridOrder��5      $��Stretch=�6*   $��10q�6H   $��Stretch=�6T      AutoGenerateColumns .  $��1��6�   $��0��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id Order��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	IdOrder+6U     5      $
 Mark��6%    63   �� *Mark+6N     5      $ Model��6%    64   �� *Model+6P     5      $
 Year��6%    63   �� *Year+6N     5      $ Transmission��6%    6;   �� *Transmission+6^     5      $ Horse Power��6%    6:   �� *
HorsePower+6[     5      $ 	Work name��6%    68   �� *
WorkName+6W     5      $ Begin��6%    64   �� *	WorkBegin+6T     5      $	 End��6%    62   �� *	WorkEnd+6P     5      $ Salary��6%    65   �� *Salary+6R   	   RowDetailsTemplate	 5      �� 5      .R�5      �� ��5      `� 5      
 �� StringFormat$
 {0} {1} {2} {3}  {4}��6+   .1�5    "   ��  �� Path$ 	FirstName�6*   6=   �� 5!   "   $ 
SecondName�6*   6>   �� 5"   "   $ 	ThirdName�6*   6=   �� 5#   "   $ Phone�6*   69   �� 5$   "   $ Birth�6*   69   5%      5'      5(      5*      �� 5+   
   -   5        $ Button_Load_Xml��5+      $��0��6   $��Load Xml��68   $
��Left=�6K   $	��Top=�6f   $��75��6~   $��
107,10,0,0q�6�   $��20��6�   �� 5,   
   -   5        $ Button_Load_Bin��5,      $��0��6   $��Load Binary��68   $
��Left=�6N   $��
204,10,0,0q�6i   $	��Top=�6}   $��75��6�   $��20��6�   5.      5/      