import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:app_quan_ao/constant.dart';
import 'package:app_quan_ao/pages/registration_screens/components/social_login_btn.dart';
import 'package:app_quan_ao/model/CKhachHang.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;

import 'login_screen.dart';

Future<User> createUser(String email, String pass, String name, String phone) async {
  final response = await http.post(Uri.parse('https://localhost:44313/Api/Customer/Register'),
  headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, String>{
      'email': email,
      'pass' : pass,
      'name' : name,
      'phone': phone,
    }),
  );
  if (response.statusCode == 200) {
    // If the server did return a 201 CREATED response,
    // then parse the JSON.
    return User.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 201 CREATED response,
    // then throw an exception.
    throw Exception('Failed to create user.');
  }
}
class SignUpScreen extends StatefulWidget {
  const SignUpScreen({Key? key}) : super(key: key);

  @override
  _SignUpScreenState createState() => _SignUpScreenState();
}

class _SignUpScreenState extends State<SignUpScreen> {
  final _formKey = GlobalKey<FormState>();
  var emailTextController = TextEditingController();
  var passwordTextController = TextEditingController();
  var confirmpasswordTextController = TextEditingController();
  var nameTextController = TextEditingController();
  var phoneTextController = TextEditingController();
  bool isvisible = true;
  bool confirmisvisible = true;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: kWhiteColor,
      body: SafeArea(
        child: SizedBox(
          width: double.infinity,
          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 15.0),
            child: SingleChildScrollView(
              child: Form(
                key: _formKey,
                child: Column(
                  children: [
                    const SizedBox(
                      height: 50,
                    ),
                    const Text(
                      "Sign Up",
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    const SizedBox(
                      height: 30,
                    ),
                    Container(
                      padding: const EdgeInsets.only(left: 15.0),
                      decoration: BoxDecoration(
                        color: kGrayColor,
                        borderRadius: BorderRadius.circular(50),
                      ),
                      child: TextFormField(
                        controller: emailTextController,
                        keyboardType: TextInputType.emailAddress,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Enter Email";
                          }
                          //now we use email validator package
                          final bool _isvalid =
                              EmailValidator.validate(emailTextController.text);
                          if (!_isvalid) {
                            return "Email was entered incorrectly";
                          }
                          return null;
                        },
                        decoration: const InputDecoration(
                          suffixIcon: Icon(Icons.email_outlined),
                          hintText: "Email",
                          enabledBorder: InputBorder.none,
                          focusedBorder: InputBorder.none,
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 30,
                    ),
                    Container(
                      padding: const EdgeInsets.only(left: 15.0),
                      decoration: BoxDecoration(
                        color: kGrayColor,
                        borderRadius: BorderRadius.circular(50),
                      ),
                      child: TextFormField(
                        controller: nameTextController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Enter Your Name";
                          }

                          return null;
                        },
                        decoration: const InputDecoration(
                          suffixIcon: Icon(Icons.person_outline),
                          hintText: "Name",
                          enabledBorder: InputBorder.none,
                          focusedBorder: InputBorder.none,
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 30,
                    ),
                    Container(
                      padding: const EdgeInsets.only(left: 15.0),
                      decoration: BoxDecoration(
                        color: kGrayColor,
                        borderRadius: BorderRadius.circular(50),
                      ),
                      child: TextFormField(
                        controller: phoneTextController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Enter Your Phone";
                          }

                          return null;
                        },
                        decoration: const InputDecoration(
                          suffixIcon: Icon(Icons.phone_android_sharp),
                          hintText: "Phone",
                          enabledBorder: InputBorder.none,
                          focusedBorder: InputBorder.none,
                        ),
                      ),
                    ),
                    //password field
                    const SizedBox(
                      height: 20,
                    ),
                    Container(
                      padding: const EdgeInsets.only(left: 15.0),
                      decoration: BoxDecoration(
                        color: kGrayColor,
                        borderRadius: BorderRadius.circular(50),
                      ),
                      child: TextFormField(
                        obscureText: isvisible,
                        controller: passwordTextController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Enter Password";
                          }

                          return null;
                        },
                        decoration: InputDecoration(
                          suffixIcon: IconButton(
                            onPressed: () {
                              setState(() {
                                isvisible = !isvisible;
                              });
                            },
                            icon: isvisible == true
                                ? Icon(Icons.visibility)
                                : Icon(Icons.visibility_off),
                            color: isvisible == true
                                ? kTextGrayColor
                                : kPrimaryColor,
                          ),
                          hintText: "Password",
                          enabledBorder: InputBorder.none,
                          focusedBorder: InputBorder.none,
                        ),
                      ),
                    ),
                    //confirm password field
                    const SizedBox(
                      height: 20,
                    ),
                    Container(
                      padding: const EdgeInsets.only(left: 15.0),
                      decoration: BoxDecoration(
                        color: kGrayColor,
                        borderRadius: BorderRadius.circular(50),
                      ),
                      child: TextFormField(
                        obscureText: confirmisvisible,
                        controller: confirmpasswordTextController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return "Enter Password";
                          }
                          if (passwordTextController.text !=
                              confirmpasswordTextController.text) {
                            return "Password not Matched";
                          }

                          return null;
                        },
                        decoration: InputDecoration(
                          suffixIcon: IconButton(
                            onPressed: () {
                              setState(() {
                                confirmisvisible = !confirmisvisible;
                              });
                            },
                            icon: confirmisvisible == true
                                ? Icon(Icons.visibility)
                                : Icon(Icons.visibility_off),
                            color: confirmisvisible == true
                                ? kTextGrayColor
                                : kPrimaryColor,
                          ),
                          hintText: "Re-Enter Password",
                          enabledBorder: InputBorder.none,
                          focusedBorder: InputBorder.none,
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 30,
                    ),
                    //sign Up Button
                    MaterialButton(
                      color: kPrimaryColor,
                      minWidth: double.infinity,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50),
                      ),
                      height: 50,
                      onPressed: () async {
                        if (_formKey.currentState!.validate()) {
                          final response = await http.post(Uri.parse('https://localhost:44313/Api/Customer/Register'),
                            headers: <String, String>{
                                'Content-Type': 'application/json; charset=UTF-8',
                              },
                              body: jsonEncode(<String, String>{
                                'email': emailTextController.text,
                                'pass' : passwordTextController.text,
                                'name' : nameTextController.text,
                                'phone': phoneTextController.text,
                              }),
                            );
                            if (response.statusCode == 200) {                                                      
                              showDialog(
                                context: context, 
                                builder: (context) => AlertDialog(
                                  title: const Text('Thông Báo'),
                                  content: const Text('Đăng ký thành công'),
                                  actions: [
                                    TextButton(
                                      onPressed: () => Navigator.pop(context,'Cancel'), 
                                      child: const Text('Cancel')
                                    ),
                                    TextButton(
                                      onPressed: () => Navigator.push(
                                          context,
                                          MaterialPageRoute(
                                              builder: (context) => const LoginScreen())), 
                                      child: const Text('Ok')
                                    ),
                                  ],
                                )
                              );
                            } else {
                              throw Exception('Failed to create user.');
                            }
                        }
                      },
                      child: const Text(
                        "Sign Up",
                        style: TextStyle(
                          color: kWhiteColor,
                          fontSize: 16,
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 20,
                    ),
                    SocialLoginBtn(),
                    const SizedBox(
                      height: 30,
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        const Text(
                          "Already a member ?",
                          style: TextStyle(
                            color: kTextGrayColor,
                          ),
                        ),
                        const SizedBox(
                          width: 10,
                        ),
                        InkWell(
                          onTap: () {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => const LoginScreen()));
                          },
                          child: const Text(
                            "Log in",
                            style: TextStyle(
                                color: kPrimaryColor,
                                fontWeight: FontWeight.w600),
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

}
