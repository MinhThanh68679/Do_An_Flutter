// ignore_for_file: unnecessary_string_interpolations

import 'package:app_quan_ao/model/CKhachHang.dart';
import 'package:flutter/material.dart';
import 'package:app_quan_ao/constant.dart';
import 'package:app_quan_ao/pages/Home/components/bottom_bar.dart';
import 'package:app_quan_ao/pages/Home/components/enum.dart';
import 'package:email_validator/email_validator.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class ProfileScreen extends StatelessWidget {
  const ProfileScreen({Key? key,required this.customer}) : super(key: key);
  final User customer;

  @override
  Widget build(BuildContext context) {
    final _formKey = GlobalKey<FormState>();
    var emailTextController = TextEditingController();
    var nameTextController = TextEditingController();
    var phoneTextController = TextEditingController();
    emailTextController.text = customer.email;
    nameTextController.text = customer.name;
    phoneTextController.text = customer.phone;

    return Scaffold(
      backgroundColor: kWhiteColor,
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        title: const Text("Thông tin của tôi",
            style: TextStyle(
              color: kTextGrayColor,
            )),
        elevation: 0,
        iconTheme: const IconThemeData(color: Colors.black),
      ),
      bottomNavigationBar: const CustomBottomBar(selectMenu: MenuState.profile),
      body: SafeArea(
        child: Form(
          key: _formKey,
          child: 
            Column(
              children: [
                Image.asset(
                  "${customer.image}",
                  height: 120,
                  width: 120,
                  fit: BoxFit.contain,
                ),
                const SizedBox(
                  height: 15,
                ),
                 Text(
                  "${customer.name}",
                  textAlign: TextAlign.center,
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20.0),
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
                            return "Enter Name";
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
                            return "Enter phone";
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
                    const SizedBox(
                      height: 30,
                    ),
                    MaterialButton(
                      color: kPrimaryColor,
                      minWidth: double.infinity,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50),
                      ),
                      height: 50,
                      onPressed: () async {
                        if (_formKey.currentState!.validate()) {
                          final response = await http.put(Uri.parse('https://localhost:44313/Api/Customer/Update'),
                            headers: <String, String>{
                                'Content-Type': 'application/json; charset=UTF-8',
                              },
                              body: jsonEncode(<String, String>{
                                //'maKH': customer.id,
                                'email': emailTextController.text,
                                'tenKH' : nameTextController.text,
                                'sdt': phoneTextController.text,
                              }),
                            );
                            if (response.statusCode == 200) {                                                      
                              showDialog(
                                context: context, 
                                builder: (context) => AlertDialog(
                                  title: const Text('Thông Báo'),
                                  content: const Text('Chỉnh sửa thông tin thành công'),
                                  actions: [
                                    TextButton(
                                      onPressed: () => Navigator.pop(context,'Cancel'), 
                                      child: const Text('Cancel')
                                    ),
                                    TextButton(
                                      onPressed: () => Navigator.pop(context,'Ok'), 
                                      child: const Text('Ok')
                                    ),
                                  ],
                                )
                              );
                            } else {
                              throw Exception('Failed to update user.');
                            }
                        }
                      },      
                      child: const Text(
                        "Chỉnh Sửa",
                        style: TextStyle(
                          color: kWhiteColor,
                          fontSize: 16,
                        ),
                      ),
                    )                   
              ],
            )
        ),
      ),
    );
  }
}
