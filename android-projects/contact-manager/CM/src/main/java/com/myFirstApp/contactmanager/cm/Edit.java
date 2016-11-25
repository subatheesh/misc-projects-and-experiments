package com.myFirstApp.contactmanager.cm;

import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.provider.MediaStore;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;


public class Edit extends ActionBarActivity {


    EditText nametxt, phonetxt, emailtxt, addresstxt;
    ImageView imgView;
    Uri imgUri = null;
    int editIndex = MainActivity.longCLickedItemIndex;
    //Bitmap bt;

    @Override
    public void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.edit);

        //communication btw activities
       // Bundle extras = getIntent().getExtras();
       // if (extras != null) {
        //    editIndex = extras.getInt("EditIndex");
      //  }

        nametxt = (EditText) findViewById(R.id.txtName);
        phonetxt = (EditText) findViewById(R.id.txtPhoneNumber);
        emailtxt = (EditText) findViewById(R.id.txtEmailID);
        addresstxt = (EditText) findViewById(R.id.txtAddress);
        imgView = (ImageView) findViewById(R.id.imgEditContactImage);

        Contact contact =MainActivity.Contacts.get(editIndex);

        nametxt.setText(contact.getName());
        phonetxt.setText(contact.getPhone());
        emailtxt.setText(contact.getEmail());
        addresstxt.setText(contact.getEmail());
        imgView.setImageURI(contact.getImgUri());
        imgUri=contact.getImgUri();

        final Button edit = (Button) findViewById(R.id.btnEdit);

        edit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                MainActivity.Contacts.get(editIndex).setId(editIndex);
                MainActivity.Contacts.get(editIndex).setName(nametxt.getText().toString());
                MainActivity.Contacts.get(editIndex).setPhone(phonetxt.getText().toString());
                MainActivity.Contacts.get(editIndex).setEmail(emailtxt.getText().toString());
                MainActivity.Contacts.get(editIndex).setAddress(addresstxt.getText().toString());
                MainActivity.Contacts.get(editIndex).set_imgUri(imgUri);
                MainActivity.dbHandler.updateContact(MainActivity.Contacts.get(editIndex));

                MainActivity.contactAdapter.notifyDataSetChanged();
                finish();
            }
        });

        imgView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                startActivityForResult(Intent.createChooser(intent, "Select contact Image"), 2);
            }
        });


    }




    @Override
    public void onActivityResult(int reqCode, int resCode, Intent data) {
        super.onActivityResult(reqCode,resCode,data);

        if(resCode==RESULT_OK) if (reqCode == 2) {

            imgUri = data.getData();
            imgView.setImageURI(imgUri);

        }

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.edit, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);


    }

}
