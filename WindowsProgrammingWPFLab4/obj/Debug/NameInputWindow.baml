   M S B A M L   `   `   `  ����T  PWindowsProgrammingWPFLab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WindowsProgrammingWPFLab4WindowsProgrammingWPFLab4  5   	   /    )WindowsProgrammingWPFLab4.NameInputWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:WindowsProgrammingWPFLab4     5   	   -   5          � Title$  You won!��5   	   $��295.445��6   $��461.388��6+    � 	Resources 5	         validationTemplate-   'WindowsProgrammingWPFLab4.BoardSizeRule  BoardSizeValidation  textBoxInError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path.   (WindowsProgrammingWPFLab4.NameLengthRule  NameRule��%�  &	        &	 r     &	 �     &	 F    �� 5
   
   .R�5      ]� .+�5      �� 
���  ��$��20(�6-   !6>   �� 5      5      5        5   
   6   �� 5   
   " ��6'    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5   	   �� #	 Z $)
 #(Validation.Errors)[0].ErrorContent�5      5        5   
   6   5      .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Name:��6   $
��Left=�6/   $��	17,42,0,0q�6J   $	��Top=�6]   $��33��6u   $��56��6�   �� 5   
   -   5         ��Name$ NameBox��5      $
��Left=�6#   $��44��6>   $��
114,46,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6s   $	��315��6�   $��15(�6�    =� ErrorTemplate# [  5    
   #��[ 6I   .��6r   ��5!      �� 5"      $

 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�5#       �� Mode$ TwoWay=�68    �� ValidationRules 5$        5%      5'      .��5(      5)      �� 5,   
   -   5         ��Name$ CancelButton��5,      $��Cancel��6'   $
��Left=�68   $��
-2,214,0,0q�6S   $	��Top=�6g   $	��230��6   $��50��6�   6�   �� 5-   
   -   5        $ OkButton��5-      $��OK��6#   $
��Left=�60   $��228,214,0,0q�6K   $	��Top=�6`   $	��225��6x   $��50��6�   6�   �� 5.   
   -   5        $ 
ErrorLabel��5.      $
��Left=�6Z   
���  ��$��
10,119,0,0q�6�   $	��Top=�6�   $��54��6�   $	��419��6�   ��6$   ��  �� ElementName$ NameBox��$
 ToolTip�6�   50      51      