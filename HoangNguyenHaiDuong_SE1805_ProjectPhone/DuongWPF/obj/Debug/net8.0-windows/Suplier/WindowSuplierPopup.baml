   M S B A M L   `   `   `  ����C  ?DuongWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DuongWPF.SuplierDuongWPF.Suplier  5   	   )    #DuongWPF.Suplier.WindowSuplierPopup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DuongWPF.Suplier     5   	     � Title$  Nhà cung cấp��5   	   $	��500��6   $	��600��6+   .��5	      � ��5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #3A8DFF��6    � Offset$ 0Q�6/   � 5      $ #FFFFFF��6   $ 1Q�6/   5      .+�5   
   �� ���#ECF0F1 �� CornerRadius$ 25��6&   ���#34495E$��1q�6N   $��Center=�6b   $��Center=�6   $	��500��6�   $	��350��6�   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   .+�5      �� $��Thêm công ty��6   $��Center=�60   ���#34495E$��20(�6b   $
��Bold"�6p   $��	0,10,0,20q�6�   $��0��6�   �� 5       �� Orientation$ Vertical=�6   $��10q�64   $��1��6@   .+�5       �� $ 
Horizontal=�6!   $��5q�6:   .+�5!      �� $��Tên công ty:��6    $	��150��67   ���#34495E$��Center=�6X   �� 5"      -   5        	 ��Name$	 txtFullName��5"   "   $	��200��67   ���#ECF0F1���#34495E���#34495E6m   5#      �� 5%      $ 
Horizontal=�6!   $��5q�6:   .+�5&      �� $��Địa chỉ:��6    $	��150��63   ���#34495E$��Center=�6T   �� 5'      -   5        $	 
txtAddress��5'   "   $	��200��66   ���#ECF0F1���#34495E���#34495E6l   5(      �� 5*      $ 
Horizontal=�6!   $��5q�6:   .+�5+      �� $��Số điện thoại:��6    $	��150��69   ���#34495E$��Center=�6Z   �� 5,      -   5        $	 txtPhone��5,   "   $	��200��64   ���#ECF0F1���#34495E���#34495E6j   5-      �� 5/      $ 
Horizontal=�6!   $��5q�6:   .+�50      �� $��Email:��6    $	��150��61   ���#34495E$��Center=�6R   �� 51      -   5        $	 txtEmail��51   "   $	��200��64   ���#ECF0F1���#34495E���#34495E6j   52      �� 53      $ 
Horizontal=�6!   $��Center=�6:   $��2��6W   $��	20,10,0,0q�6d   .+�54      �� -   5        $��Thêm��54   !   $	��100��60   $��40��6<   $
��10,0q�6H   ���#3498DB
�������$
��Bold"�6~   
������ 6�   �� 55      -   5        $��Hủy��55   !   $	��100��6/   $��40��6;   $
��10,0q�6G   ���#E74C3C
�������$
��Bold"�6}   
������ 6�   56      57      5;      5<      5=      5>      