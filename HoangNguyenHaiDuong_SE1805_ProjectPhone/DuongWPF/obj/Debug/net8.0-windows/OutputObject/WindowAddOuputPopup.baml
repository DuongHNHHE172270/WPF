   M S B A M L   `   `   `  ����C  ?DuongWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DuongWPF.OutputObjectDuongWPF.OutputObject  5   	   /    )DuongWPF.OutputObject.WindowAddOuputPopup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:DuongWPF.OutputObject     5   	     � Title$  Xuất phiếu��5   	   $	��400��6   $	��700��6)   .��5	      � ��5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #3A8DFF��6    � Offset$ 0Q�6/   � 5      $ #FFFFFF��6   $ 1Q�6/   5      .+�5   
   �� ���#ECF0F1 �� CornerRadius$ 25��6&   ���#34495E$��1q�6N   $��Center=�6b   $��Center=�6   $	��450��6�   $	��300��6�   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   .+�5      �� $��Phiếu xuất��6   $��Center=�6.   ���#34495E$��20(�6`   $
��Bold"�6n   $��	0,10,0,20q�6�   $��0��6�   �� 5       �� Orientation$ Vertical=�6   $��10q�64   $��1��6@   .+�5       �� $ 
Horizontal=�6!   $��5q�6:   .+�5!      �� $��Tên vật tư:��6    $	��150��66   ���#34495E$��Center=�6W   �� 5"      -   5        	 ��Name$	 cbObject��5"   #   $	��200��65   ���#ECF0F1���#34495E���#34495E
 �� DisplayMemberPath$
 DisplayName��6�    �� SelectedValuePath$ Id��6�   5#      �� 5$      $ 
Horizontal=�6!   $��5q�6:   .+�5%      �� $��Dung lượng:��6    $	��150��66   ���#34495E$��Center=�6W   �� 5&      -   5        $	 cbCapa��5&   #   $	��200��63   ���#ECF0F1���#34495E���#34495E$
 DisplayName��6   $ Id��6�   5'      �� 5(      $ 
Horizontal=�6!   $��5q�6:   .+�5)      �� $��Số lượng:��6    $	��150��64   ���#34495E$��Center=�6U   �� 5*      -   5         ��Name$ txtCount��5*   "   $	��200��64   ���#ECF0F1���#34495E���#34495E6j   5+      �� 5,      $ 
Horizontal=�6!   $��Center=�6:   $��2��6W   $��	20,10,0,0q�6d   .+�5-      �� -   5        $��Thêm��5-   !   $	��100��60   $��40��6<   $
��10,0q�6H   ���#3498DB
�������$
��Bold"�6~   
������ 6�   �� 5/      -   5        $��Hủy��5/   !   $	��100��6/   $��40��6;   $
��10,0q�6G   ���#E74C3C
�������$
��Bold"�6}   
������ 6�   50      51      52      53      54      55      