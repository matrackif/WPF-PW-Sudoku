   M S B A M L   `   `   `  ����T  PWindowsProgrammingWPFLab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WindowsProgrammingWPFLab4WindowsProgrammingWPFLab4  5   	   /    )WindowsProgrammingWPFLab4.BoardSizePrompt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:WindowsProgrammingWPFLab4     5   	     � WindowStyle$
  None=�5   	   $��194.317��5	   	   $��442.354��6   $��194.317��5
   	   $��194.317��6   $��442.354��5   	   $��442.354��6    � 	Resources 5         validationTemplate-   'WindowsProgrammingWPFLab4.BoardSizeRule  BoardSizeValidation  textBoxInError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path��%d  &	        &	 r     &	 �     �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��20(�6-   !6>   �� 5      5      5        5   
   6   �� 5   
   " ��6'    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5   	   �� #	 Z $)
 #(Validation.Errors)[0].ErrorContent�5      5      5       .��5!      � .+�5"   
   �� -   5         ��Name$ CancelButton��5"      $��Cancel��6'   $
��Left=�68   $��	0,144,0,0q�6S   $	��Top=�6f   $	��225��6~   $��42��6�   �� 5#   
   -   5        $ OkButton��5#      $��OK��6#   $
��Left=�60   $��225,144,0,0q�6K   $	��Top=�6`   $	��209��6x   $��42��6�   6�   �� 5$   
   -   5         ��Name$ 	SizeLabel��5$      $��Size:��6#   $
��Left=�63   $��	10,28,0,0q�6N   $	��Top=�6a   �� 5&   
   -   5        $��textBox1��5&      $��15(�6"    =� ErrorTemplate# [  5'   
   $��62,31,37,120q�5(   
   #��[ 6    .��5)   
   ��5*      �� 5+      $
 	BoardSize�6    �� UpdateSourceTrigger$ PropertyChanged=�5,       �� ValidationRules 5-        5.      
   Min$ 2��6.   
   Max$ 4��66   50      .��51      52      �� 53   
   -   5        $ label��53      $
��Left=�6   $��	30,71,0,0q�6:   $	��Top=�6M   $	��372��6e   
���  ��$��55��6�   ��6�   ��  �� ElementName$ textBox1��$
 ToolTip�6�   55      56      