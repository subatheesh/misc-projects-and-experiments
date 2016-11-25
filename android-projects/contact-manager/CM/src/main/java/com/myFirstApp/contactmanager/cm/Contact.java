package com.myFirstApp.contactmanager.cm;

import android.net.Uri;

/**
 * Created by $@T!$# on 26-07-2014.
 */
public class Contact {
    private String _name,_phone,_email,_address;
    private Uri _imgUri;
    private int _id;

    public Contact(int id,String name,String phone,String email,String address,Uri imgUri)
    {
        _id=id;
        _name=name;
        _phone=phone;
        _email=email;
        _address=address;
        _imgUri=imgUri;
    }

    public int getId()
    {
        return _id;
    }
    public String getName()
    {
        return _name;
    }
    public String getPhone()
    {
        return _phone;
    }
    public String getEmail()
    {
        return _email;
    }
    public String getAddress() {
        return _address;
    }
    public Uri getImgUri() {
        return _imgUri;
    }

    public void setId(int id)
    {
         _id=id;
    }
    public void setName(String Name)
    {
         _name=Name;
    }
    public void setPhone(String phone)
    {
         _phone=phone;
    }
    public void setEmail(String email)
    {
         _email=email;
    }
    public void setAddress(String address) {
         _address=address;
    }
    public void set_imgUri(Uri imgUri) {
         _imgUri=imgUri;
    }
}
