   M S B A M L   `   `   `  ����C  ?DuongWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DuongWPF.CustomerDuongWPF.Customer  5   	   &     DuongWPF.Customer.WindowCustomer   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DuongWPF.Customer     5   	   -   5          � Title$  Khách hàng��5	   	   $	��600��6   $
��1000��6)   .��5
      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #3A8DFF��6    � Offset$ 0Q�6/   � 5      $ #FFFFFF��6   $ 1Q�6/   5      .+�5   
   �� ���#ECF0F1 �� CornerRadius$ 25��6&   ���#34495E$��1q�6N   $��Center=�6b   $��Center=�6   $	��900��6�   $	��500��6�   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   $��10q�6S   $��0��6_   .+�5      �� $��Nhập tên khách hàng:��6   $��Center=�6;   �� 5      -   5        $��SearchTextBox��5      $	��150��63   $��25��6?   $��5q�6K   �� 5       -   5        	 ��Name$	 	btnSearch��5    �   $��Tìm kiếm��6   $��5q�60   $	��100��6;   ���#3498DB
�������$
��Bold"�6o   
������ 6�   �� 5!      -   5        $	 btnLoad��5!   �   $��Tải lại��6   $	��100��6/   $��25��6;   ���#3498DB
�������$
��Bold"�6o   
������ 6�   �� 5"      -   5        $	 btnFile��5"   �   $��Xuất file excel��6   $��5q�67   $	��100��6B   ���#3498DB
�������$
��Bold"�6v   
������ 6�   �� 5#      -   5        $	 	btnReturn��5#   �   $��Trở lại��6   $��5q�6/   $	��100��6:   ���#E74C3C
�������$
��Bold"�6n   
������ 6�   5$      &   System.Windows.Controls.DataGrid  5'      -   5        $��
dgCustomer��5'      $��1��6-   $��10q�6:   
   AutoGenerateColumns$
 False��6F   
������    CanUserAddRows$ False��6{      Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-      
IsReadOnly$
 True��6P      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6b     5*      $ Tên khách hàng��6-   $
 True��6e   $ * 6w    6E   �� *DisplayName+6w     5+      $ Địa chỉ��6-   $
 True��6Z   $ * 6l    6>   �� *	Address+6l     5,      $ Điện thoại��6-   $
 True��6[   $ * 6m    6A   �� *Phone+6m     5-      $ Email��6-   $
 True��6V   $ * 6h    6<   �� *Email+6h     5.      $ Trạng thái��6-   $
 True��6\   $ * 6n    6A   �� *Status+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5/      $ Hành động��61   $
 1.5* 6D      CellTemplate 50      �� 51   "   .R�52   &   �� $ 
Horizontal=�61   $��10,0,0,0q�6J   .+�53   *   �� -   5        $��Sửa��53   1   $	��5,0q�6?   $��80��6L   ���#3498DB
�������$
��Bold"�6   
������ 6�   54   '   55   #   57      59      5:      5;      5<      5=      