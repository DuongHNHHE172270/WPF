   M S B A M L   `   `   `  ����C  ?DuongWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DuongWPFDuongWPF  5   	       DuongWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:DuongWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � ��5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #3A8DFF��6    � Offset$ 0Q�6/   � 5      $ #FFFFFF��6   $ 1Q�6/   5      .+�5   
   �� .+�5      � ���	#FF6396C9$��50��6*   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   .+�5      �� -   5         ��Name$ 
BtnNhapKho��5      $��
Nhập kho��61   
�������
������ 
������ $
��Bold"�6�   $��10q�6�   6�   �� 5      -   5        $ 
BtnXuatKho��5      $��
Xuất kho��61   
�������
������ 
������ $
��Bold"�6�   $��10q�6�   6�   �� 5      -   5        $ BtnVatTu��5      $��	Vật tư��6/   
�������
������ 
������ $
��Bold"�6�   $��10q�6�   6�   �� 5      -   5        $ BtnNhaCungCap��5      $��Nhà cung cấp��64   
�������
������ 
������ $
��Bold"�6�   $��10q�6�   6�   �� 5      -   5        $ BtnKhachHang��5      $��Khách hàng��63   
�������
������ 
������ $
��Bold"�6�   $��10q�6�   6�   �� 5      -   5        $ 	BtnLogout��5      $��Đăng xuất��60   
�������
������ 
������ $
��Bold"�6�   $��10q�6�   6�   5      5      �� 5      $��20q�6   .+�5!      �� $ 
Horizontal=�6   $
��Left=�66   $��	0,10,0,10q�6Q   .+�5"      �� $��Search��6    $
��Bold"�6.   
�������$��0,0,10,0q�6R   �� 5#      -   5         ��Name$ cbObject��5#      $	��200��61   ���#ECF0F1���#34495E���#34495E �� SelectedValuePath$ Id��5$      	 �� DisplayMemberPath$	 DisplayName��6"   .@�5%      �� ${�False��6'   $��Select an object��69   5&      �� 5'      -   5        $
��Load��5'      ���#3A8DFF
�������$��10q�6T   $��20,0,0,0q�6a   6s   5(      �� 5+      $ 
Horizontal=�6   $��Center=�66   $��	0,20,0,20q�6S   .+�5,      �� -	   5        
 ��Name$
 borderLuongNhap��5,      ���#00BFFF �� CornerRadius$ 10��6K    �� Padding$ 20q�6]   $��10q�6j   ._�5-      �� .+�5.      �� $��Lượng nhập��6(   
�������$��16(�6M   $
��Bold"�6[   $��Center=�6m   �� 5/      -
   5         ��Name$ txtLuongNhap��5/   (   
�������$��20(�6Q   $
��Bold"�6_   $��Center=�6q   50      51      �� 52      -   5        $
 borderLuongXuat��52      ���#00BFFF$ 10��6K   $ 20q�6]   $��10q�6j   ._�53      �� .+�54      �� $��Lượng xuất��6(   
�������$��16(�6M   $
��Bold"�6[   $��Center=�6m   �� 55      -   5        $ txtLuongXuat��55   (   
�������$��20(�6Q   $
��Bold"�6_   $��Center=�6q   56      57      �� 58      -   5        $
 borderTonKho��58      ���#00BFFF$ 10��6H   $ 20q�6Z   $��10q�6g   ._�59      �� .+�5:      �� $��	Tồn kho��6(   
�������$��16(�6J   $
��Bold"�6X   $��Center=�6j   �� 5;      -   5        $ 	txtTonKho��5;   (   
�������$��20(�6N   $
��Bold"�6\   $��Center=�6n   5<      5=      5>      5?      �� 5@      ���#ECF0F1$ 25��6*   ���#34495E$��1q�6R   $��Center=�6f   $��Center=�6�   $	��700��6�   $	��120��6�   ._�5A      &   System.Windows.Controls.DataGrid  -   5        $��dgDetail��5A      $��1��6,   $��10q�69      AutoGenerateColumns$ False��6E   
������    CanUserAddRows$ False��6z      Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-      
IsReadOnly$
 True��6P      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6b     5D      $
 Tên��6-   $
 True��6m   $ * 6    6:   �� * IdObjectNavigation.DisplayName+6     5E      $ Dung lượng��6-   $
 True��6^   $ * 6p    6A   �� *
Capacity+6p     5F      $ 	Tồn kho��6-   $
 True��6X   $ * 6j    6>   �� *Count+6j   5H      5I      5J      5K      5L      