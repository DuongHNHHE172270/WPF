   M S B A M L   `   `   `  ����C  ?DuongWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DuongWPF.ObjectPDuongWPF.ObjectP  5   	   *    $DuongWPF.ObjectP.WindowUpdateObPhone   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DuongWPF.ObjectP     5   	     � Title$  Cập nhật��5      $	��450��6!   $	��600��6.   .��5	      � ��5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #3A8DFF��6    � Offset$ 0Q�6/   � 5      $ #FFFFFF��6   $ 1Q�6/   5      .+�5   
   �� ���#ECF0F1 �� CornerRadius$ 25��6&   ���#34495E$��1q�6N   $��Center=�6b   $��Center=�6   $	��500��6�   $	��320��6�   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   .+�5      �� $��Cập nhật vật tư��6   $��Center=�63   ���#34495E$��20(�6e   $
��Bold"�6s   $��	0,10,0,20q�6�   $��0��6�   �� 5       �� Orientation$ Vertical=�6   $��10q�64   $��1��6@   .+�5       �� $ 
Horizontal=�6!   $��5q�6:   .+�5!      �� $��Id vật tư:��6    $	��150��65   ���#34495E$��Center=�6V   �� 5"      -   5        	 ��Name$	 txtId��5"   4   
 �� 
IsReadOnly$

 True��6"   $	��200��6C   ���#ECF0F1���#34495E���#34495E6y   5#      �� 5%      $ 
Horizontal=�6!   $��5q�6:   .+�5&      �� $��Name:��6    $	��150��60   ���#34495E$��Center=�6Q   �� 5'      -   5        $	 txtName��5'   4   $

 True��6"   $	��200��6E   ���#ECF0F1���#34495E���#34495E6{   5(      �� 5)      $ 
Horizontal=�6!   $��5q�6:   .+�5*      �� $��Tên Công ty:��6    $	��150��67   ���#34495E$��Center=�6X   �� 5+      -   5         ��Name$ 	cbSuplier��5+   5    �� 
IsReadOnly$
 True��6#   $	��200��6H   ���#ECF0F1���#34495E���#34495E �� DisplayMemberPath$ DisplayName��6�    �� SelectedValuePath$ Id��6�   5,      �� 5-      $ 
Horizontal=�6!   $��5q�6:   .+�5.      �� $��Trạng thái:��6    $	��150��66   ���#34495E$��Center=�6W   �� 5/      $ 
Horizontal=�6%   .+�50      	� -   5         	�Name$ rbActive��50   *   $��Hoạt động��6<    d� 	IsChecked$
 TrueY�6P   ���#34495E6a   	� 51      -   5        $ 
rbInactive��51   *   $��Không hoạt động��6>   $��10,0,0,0q�6X   ���#34495E6j   52      53      �� 54      $ 
Horizontal=�6!   $��Center=�6:   $��2��6W   $��	20,10,0,0q�6d   .+�55      �� -   5        $��Chỉnh sửa��55   !   $	��100��65   $��40��6A   $
��10,0q�6M   ���#3498DB
�������$
��Bold"�6�   
������ 6�   �� 56      -   5        $��Hủy��56   !   $	��100��6/   $��40��6;   $
��10,0q�6G   ���#E74C3C
�������$
��Bold"�6}   
������ 6�   57      58      59      5:      5;      5<      