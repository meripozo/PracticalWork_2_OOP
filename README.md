# PracticalWork_2_OOP
practical work II OOP ordinary 2025
<img src="./vxfahyc0.png"
style="width:4.30208in;height:1.07292in" />

> **ESCUELA** **POLITÉCNICA** **SUPERIOR**
>
> **Programación** **Orientada** **a** **Objetos**
>
> **Practical** **Work** **II**
>
> María Fernández del Pozo Romero
>
> **Grado:** Ingeniería Informática, 2 Aº
>
> **Mayo,** **2025.**

**INDEX**
**Introduction..............................................................................................................................3**
**Description** **of** **the**
**project........................................................................................................**
**3** **Class**
**Diagram...........................................................................................................................3**
**Problems....................................................................................................................................3**
**Conclusion.................................................................................................................................3**

**Introduction**

This document will explain in detail the most important and fundamental
aspects of my code development for this Graphical User Interfaces
project, including a detailed description of my solution, both the
interface design and the C# code. I will also explain the fundamental
problems I faced during the development of this project and the
solutions I considered. Finally, I will provide a conclusion to the
project.

**Description** **of** **the** **project**

In this section, I'll explain in detail the development and operation of
my solution. I'll first explain the interface design, and then the
internal logic of the .xaml.cs files.

**<u>.XAML FILES</u>**

For the .xaml files, I decided to use colorhunt.co to inspire me with a
visually pleasing color palette. I opted for dark pinks and muted
whites.

As for the interface structure, I tried to closely follow the example
interface included in the task statement.

**<u>[.XAML.CS](http://xaml.cs) FILES</u>**

To pass the user value parameters from one page to another, I decided to
use the *IQueryAttributable* library, which subsequently allowed me to
do all the “current user” logic that was necessary for the operation of
all the converter pages.

> *●* *ConversorPage.xaml.cs:*
>
> In this file, the most important function is the following: the
> *OperationsCounter()* function, which first reads the .txt file,
> reading all the lines to find the current user. For that current user,
> the number of operations performed is added, and then that line of the
> file is modified.
>
> For each conversion in the calculator, we first call *Validate()* to
> ensure the input is correct. Then we use the corresponding function,
> which will convert the input to the desired number system.
>
> *●* *RegisterPage.xaml.cs:*
>
> In this file, the user is able to register so that it can then log in
> and access the conversor. It will ask the user to enter a username,
> name, email, password and a confirmation of the password. These
> information entries follow some validation rules. These include that,
> the username and name must be different, the password must be at least
> 8 characters long and must have an uppercase letter, a lowercase
> letter, a symbol and a number. For the email, it must contain
>
> a “@” and the confirmation of the password must match the password.
> For these validations that the heading asked for, I used this library:
> *System.Text.RegularExpressions;*. Also, before being able to register
> the user, you will need to check the box of the policy terms.
>
> *●* *ForgotPasswordPage.xaml.cs:*
>
> In this file, the user is able to change their password. For this, we
> first read the file to see that the username entered exists. Once this
> is validated, the new password entered replaces the password that was
> currently saved in the file. This way the new password gets saved
> inside the file.
>
> *●* *UserInfoPage.xaml.cs:*
>
> In this file, displays the information of the current user by reading
> the file and displaying all the information.
>
> *●* *LoginPage.xaml.cs:*
>
> In this file, the user writes their username and password. Then the
> program reads all lines of the text file and, if the username and
> password that the user imputed appear and file and match correctly,
> then the user is able to access the conversor.

**Maui** **Class** **Diagram**

The class diagram of my project, which includes the relationships
between them, is as follows:

<img src="./scjsafpd.png"
style="width:6.27083in;height:4.19792in" />

![image](https://github.com/user-attachments/assets/e63e4c56-6260-4a4e-a945-d4c69f8e2388)

**Problems**

> \- Initial challenge: familiarizing myself with how the Maui code
> works. Initially, I didn't fully understand how Maui worked in
> general, so the interfaces weren't very visually organized at first,
> nor did they correctly direct you to the page you were supposed to
> navigate to.
>
> \- I also had problems connecting the *ConverterPage.xaml.cs* to the
> old activity classes. I wasn't sure how to connect them. I started by
> instantiating the converter class, but it didn't recognize the classes
> or any of the functions I needed to implement. Therefore, I opted to
> do it differently: for each type of conversion, I created an instance
> of the corresponding class, then called the *Validate()* function of
> that object, and then called *Change()*.

<img src="./gk2xj4hw.png"
style="width:6.27083in;height:2.32292in" />

> \- I also had a lot of questions about how to handle all the
> registration, login, and user info functions. I didn't know if I
> should create a user class and instantiate it, then use the user
> attributes directly to later write to the .txt file. This wasn't very
> efficient in the code, so I ended up using a User class with the
> attributes. This is where I write the newly created user to the .txt
> file using the *UserWriteToFile()* function.
>
> \- I should also mention the problems I had managing the current user:
> at first, I tried to manage it by using a User object through the
> constructor of the functions that needed it. However, I wasn't able to
> do it this way because it had a lot of errors and I didn't know how to
> do it. Finally, I opted for another solution: I decided to do it with
> the *IQueryAttributable* interface, which allowed me to pass current
> user parameters from one page to another when needed. This way, I was
> able to make the pages that depended on the current user work.
>
> \- Furthermore, I've had a lot of problems writing to the .txt file,
> because it would overwrite things and lose old users. To fix this
> problem and prevent it from writing to the .txt file, but instead
> appending the new user after the last one, in the form of a list, I
> used the *File.AppendText* function, studied in class, for the
> *UserWriteToFile()* function.
>
> \- However, I must emphasize that my biggest problem has been
> correctly ordering and constructing the loops that allow user
> validation to work and subsequently writing them to the .txt file. I
> often wrote the loop condition incorrectly, or ordered them in a
> certain way and the DisplayAlerts didn't pop up, or I didn't register
> the users correctly. For example, when I tried to validate the login
> page, if it was the correct user, like I did a *ReadAllLines* to find
> the user in the .txt file, when it found the correct one, it let you
> go to the converter. But from that correct line in the .txt file to
> the end of the .txt file, the rest of the users were obviously
> incorrect, and then it sent an error message for each user in the file
> that wasn't the one logged in. I fixed this by creating a Boolean
> variable, "*userfound*," which I used to manage the logic behind the
> conditions in my loops.

<img src="./q310asrd.png"
style="width:4.55208in;height:2.53125in" />

> I have also used this remedy on other pages of the project, such as
> *RegisterPage*, to check that the user has not registered before
> (*!userfound*).

**Conclusion**

Completing this project has been particularly enriching for me, as it has allowed us to acquire a deeper and more comprehensive understanding of the design, implementation, and application of concepts learned in the Object-Oriented Programming course. I believe this experience will be very useful for my future career, as proper handling of these GUI interfaces is a fundamental skill in many IT-related work environments.

In conclusion, this project has not only allowed me to consolidate theoretical concepts but also to face practical situations that required me to make decisions and think of new ways to resolve errors in my code. All of this has contributed to meaningful learning that is applicable to future professional contexts.
