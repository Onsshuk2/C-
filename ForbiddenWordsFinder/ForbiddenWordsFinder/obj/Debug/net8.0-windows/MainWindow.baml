   M S B A M L   `   `   `  ����  ForbiddenWordsFinder%    ForbiddenWordsFinder.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  File Scanner��5   	   $	��450��6   $	��800��6+   ���	#FFF0E68C.��5      � .+�5   
   �� $!��Enter or load banned words:��6   $	��Top=�66   $
��Left=�6N   $��	10,10,0,0q�6i   �� 5   
   -   5         ��Name$ txtBannedWords��5      $	��Top=�6*   $
��Left=�6B   $��	10,30,0,0q�6]   $	��400��6p   $	��100��6|    �� AcceptsReturn$
 True��6�   �� 5	   
   -   5        $��Load from file��5	      $	��Top=�6*   $
��Left=�6B   $��
420,30,0,0q�6]   $	��120��6q   6}   �� 5   
   -   5        $��Select Files��5      $	��Top=�6(   $
��Left=�6@   $��
10,140,0,0q�6[   $	��100��6o   6{   �� 5   
   -   5        $��Start��5      $	��Top=�6!   $
��Left=�69   $��120,140,0,0q�6T   $	��100��6i   6u   � 5   
   -   5         �Name$ progressBar��5       � Minimum$ 0Q�6+    � Maximum$	 100Q�67   $��20��6E   $	��Top=�6Q   $��
10,180,0,0q�6i   �� 5   
   -   5         ��Name$ 	lblStatus��5      $�� ��6#   $	��Top=�6.   $
��Left=�6F   $��
10,210,0,0q�6a   �� 5   
   -   5        $ 
txtResults��5      $	��200��6&   $	��400��63    �� TextWrapping$
 Wrap=�6?   $
 True��6S   " �� VerticalScrollBarVisibility$
 Auto=�6h   $	��Top=�6�   $��
10,240,0,0q�6�   5      5      