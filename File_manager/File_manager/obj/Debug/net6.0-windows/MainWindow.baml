   M S B A M L   `   `   `  ����  File_manager"    SimpleFileManager.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Simple File Manager��5   	   $	��450��6%   $	��800��62   ���#2E2E2E���#FFFFFF$��Segoe UI)�5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   'Q�       '�� p     �� 5   
   " Q�6   .�5      ��  � ��
 �����6+   �� 5       � ��
 ���� 6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 ���� 6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��304 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5       $
��Auto �6   .+�5#   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��	0,10,0,10q�6X   $	��758��6k   $��2��6w   .+�5$      �� -   5        $	��←��5$      $��40��6!   6,   �� 5%      -   5        $��Create Folder��5%      $��80��6-   68   �� 5&      -   5        $��Create File��5&      $��80��6+   66   �� 5'      -   5        $��Delete��5'      $��80��6&   61   �� 5(      -   5        $��Rename��5(      $��80��6&   61   5)      R� 5+   
   -   5         R�Name$ FolderTreeView��5+      $��0��6+   $��1��6;   $��10,10,10,10q�6H   ���#3C3C3C
�������6�   �� 5-   
   -   5        	 ��Name$	 FileList��5-      $��1��6$   $��1��64   $��10,10,10,10q�6A   ���#3C3C3C
�������6k   �� 5/   
   -   5        
 ��Name$
 CurrentPathTextBlock��5/      $��0��62   $��2��6B   $��2��6V   $��Current Path: C:\��6c   $��10,10,10,10q�6|   $��16(�50      $
��Bold"�6"   ���#BBBBBB64   51      52      