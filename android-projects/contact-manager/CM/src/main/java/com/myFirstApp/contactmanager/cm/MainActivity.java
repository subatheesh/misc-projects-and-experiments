package com.myFirstApp.contactmanager.cm;

import android.app.AlertDialog;
import android.app.Service;
import android.content.ActivityNotFoundException;
import android.content.ComponentName;
import android.content.DialogInterface;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.net.Uri;
import android.content.Intent;
import android.os.Environment;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Filter;
import android.widget.ListView;
import android.widget.TabHost;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.Filterable;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends ActionBarActivity {

    public final static int EDIT =0;
    public final static int DELETE =1;

     EditText nametxt,phonetxt,emailtxt,addresstxt,ser;
    ImageView imgView;
    ListView contactListView;
    Bitmap thePic;
    Uri imgUri=Uri.parse("android.resource://com.myFirstApp.contactmanager.cm/"+R.drawable.contact);
    public static List<Contact> Contacts = new ArrayList<Contact>();
   public static int longCLickedItemIndex;
    public static ArrayAdapter<Contact> contactAdapter;
public static DatabaseHandler dbHandler;
SearchFilter searchFilter = new SearchFilter();
    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        nametxt = (EditText) findViewById(R.id.txtName);
        phonetxt = (EditText) findViewById(R.id.txtPhoneNumber);
        emailtxt = (EditText) findViewById(R.id.txtEmailID);
        addresstxt = (EditText) findViewById(R.id.txtAddress);
        imgView = (ImageView) findViewById(R.id.imgAddContactImage);
        contactListView=(ListView) findViewById(R.id.listView);
        ser=(EditText) findViewById(R.id.ser);
        dbHandler = new DatabaseHandler(getApplicationContext());
        File f = new File(Environment.getExternalStorageDirectory()
                + File.separator +"CMdp/");
        f.mkdirs();

        TabHost tabHost = (TabHost) findViewById(R.id.tabHost);

        tabHost.setup();

        TabHost.TabSpec  tabSpec = tabHost.newTabSpec("list");

        tabSpec.setContent(R.id.tabContactList);
        tabSpec.setIndicator("List");
        tabHost.addTab(tabSpec);

        tabSpec = tabHost.newTabSpec("create");
        tabSpec.setContent(R.id.tabCreator);
        tabSpec.setIndicator("Create");
        tabHost.addTab(tabSpec);


        registerForContextMenu(contactListView);

        contactListView.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {

                longCLickedItemIndex=position;
                return false;
            }
        });

        final Button addbtn = (Button) findViewById(R.id.btnAdd);

        addbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {


                ByteArrayOutputStream bytes = new ByteArrayOutputStream();
                thePic.compress(Bitmap.CompressFormat.JPEG, 40, bytes);
//you can create a new file name "test.jpg" in sdcard folder.
                File f = new File(Environment.getExternalStorageDirectory()
                        + File.separator +"CMdp/"+ nametxt.getText()+".jpg");
                try {
                    f.createNewFile();
//write the bytes in file
                    FileOutputStream fo = new FileOutputStream(f);
                    fo.write(bytes.toByteArray());

// remember close de FileOutput
                    fo.close();
                    imgUri=Uri.fromFile(f);
                }catch (IOException e)
                {
                    Log.i("Test", e.toString());
                }


                Contact contact = new Contact(dbHandler.getContactsCount() + 1, nametxt.getText().toString(), phonetxt.getText().toString(), emailtxt.getText().toString(), addresstxt.getText().toString(), imgUri);
                if (!contactExists(contact)) {
                    dbHandler.createContact(contact);
                    Contacts.add(contact);
                    // populateList(); NO NEED to populate list every time
                    contactAdapter.notifyDataSetChanged();
                    Toast.makeText(getApplicationContext(), nametxt.getText().toString().toUpperCase() + " has been added to your Contacts!", Toast.LENGTH_SHORT).show();
                } else
                    Toast.makeText(getApplicationContext(), nametxt.getText().toString().toUpperCase() + " Already Exists! Please use a different Name.", Toast.LENGTH_SHORT).show();
                //backing to defaults
                nametxt.setText("");
                phonetxt.setText("");
                emailtxt.setText("");
                addresstxt.setText("");
                imgView.setImageURI(null);
                imgView.setImageURI(Uri.parse("android.resource://com.myFirstApp.contactmanager.cm/" + R.drawable.addcontact));

            }
        });
        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
    nametxt.addTextChangedListener( new TextWatcher() {
            @Override
           public void beforeTextChanged(CharSequence s, int start, int count, int after) {
          }

         @Override
         public void onTextChanged(CharSequence s, int start, int before, int count) {
           addbtn.setEnabled(String.valueOf(nametxt.getText()).trim().length()>0);
          }

           @Override
          public void afterTextChanged(Editable s) {
          }

          });



        ser.addTextChangedListener(new TextWatcher() {
    @Override
    public void beforeTextChanged(CharSequence s, int start, int count, int after) {

    }


    @Override
    public void onTextChanged(CharSequence s, int start, int before, int count) {
        contactAdapter.getFilter().filter(s.toString());
    }

    @Override
    public void afterTextChanged(Editable s) {

    }
});
        imgView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                startActivityForResult(Intent.createChooser(intent, "Select contact Image"), 1);
               /* Intent i = new Intent(Intent.ACTION_PICK,android.provider.MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                startActivityForResult(i, 0);*/
            }
        });

//Initializing DB

        if(contactListView.getCount()==0)
            Contacts.addAll(dbHandler.getAllContacts());
            populateList();

        final SwipeDetector swipeDetector = new SwipeDetector();
        contactListView.setOnTouchListener(swipeDetector);
        contactListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                final int p = position;
                if (swipeDetector.LRDetected()) {
               String phno;

                   phno=Contacts.get(p).getPhone();
                   Intent callIntent = new Intent(Intent.ACTION_CALL);
                   callIntent.setData(Uri.parse("tel:"+phno));
                   startActivity(callIntent);
                    Toast.makeText(MainActivity.this,  " Calling "+Contacts.get(p).getName()+"...!", Toast.LENGTH_LONG).show();
               }
                else if (swipeDetector.RLDetected()) {

                     AlertDialog.Builder alert = new AlertDialog.Builder(MainActivity.this);
                    final EditText input = new EditText(MainActivity.this);
                   alert.setTitle("Enter Message");
                   alert.setMessage("Not over 160 words !");
                    alert.setIcon(R.drawable.ic_sms);

// Set an EditText view to get user input
                   alert.setView(input);

                   alert.setPositiveButton("SEND", new DialogInterface.OnClickListener() {
                       public void onClick(DialogInterface dialog, int whichButton) {
                           String message = input.getText().toString();
                           String phno;
                           phno=Contacts.get(p).getPhone();
                           SmsManager smsManager = SmsManager.getDefault();
                           smsManager.sendTextMessage(phno,null,message,null,null);
                           Toast.makeText(MainActivity.this,  " Sending Message to "+Contacts.get(p).getName()+"...!", Toast.LENGTH_LONG).show();
                       }
                   });

                   alert.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                       public void onClick(DialogInterface dialog, int whichButton) {
                           //do nothing and hide alert
                       }
                   });

                   alert.show();

                }
            }
        });
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
         Contacts.clear();
    }

    private boolean contactExists(Contact contact)
    {
        String name = contact.getName();

        int contactsCount = Contacts.size();

        for(int i=0;i<contactsCount;i++)
        {
            if(name.compareToIgnoreCase(Contacts.get(i).getName())==0)
            {
             return true;
            }
        }

        return false;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);

        menu.setHeaderIcon(R.drawable.edit);
        menu.setHeaderTitle("Options");
        menu.add(Menu.NONE,EDIT,menu.NONE,"Edit");
        menu.add(Menu.NONE,DELETE,menu.NONE,"Delete");
    }


    @Override
    public boolean onContextItemSelected(MenuItem item) {

        switch(item.getItemId())
        {
            case EDIT:
                Intent i = new Intent(getApplicationContext(), Edit.class);
                //i.putExtra("EditIndex",longCLickedItemIndex);
                startActivity(i);
                break;
            case DELETE:
                dbHandler.deleteContact(Contacts.get(longCLickedItemIndex));
                Contacts.remove(longCLickedItemIndex);
                contactAdapter.notifyDataSetChanged();
                break;
        }

        return super.onContextItemSelected(item);
    }

    @Override
    public void onActivityResult(int reqCode,int resCode,Intent data)
    {
        super.onActivityResult(reqCode,resCode,data);

        if(resCode==RESULT_OK) {
            if (reqCode == 1) {

                imgUri = data.getData();
                imgView.setImageURI(imgUri);

                try {
                    Intent intent = new Intent("com.android.camera.action.CROP");
                    intent.setType("image/*");

                    List<ResolveInfo> list = getPackageManager().queryIntentActivities( intent, 0 );
                    int size = list.size();

                    if (size >= 0) {
                        intent.setData(imgUri);
                        intent.putExtra("crop", "false");
                        intent.putExtra("aspectX", 1);
                        intent.putExtra("aspectY", 1);
                        intent.putExtra("outputX", 256);
                        intent.putExtra("outputY", 256);
                        intent.putExtra("scale", true);
                        intent.putExtra("return-data", true);

                        Intent i = new Intent(intent);
                        ResolveInfo res = list.get(0);
                        i.setComponent( new ComponentName(res.activityInfo.packageName, res.activityInfo.name));

                        startActivityForResult(i,3);
                    }

                }
                catch(ActivityNotFoundException anfe){
                    String errorMessage = "Whoops - your device doesn't support the crop action!";
                    Toast toast = Toast.makeText(this, errorMessage, Toast.LENGTH_SHORT);
                    toast.show();
                }
            }
            else if(reqCode==3)
            {
                Bundle extras = data.getExtras();
                thePic = extras.getParcelable("data");

     imgView.setImageBitmap(thePic);
              }


            }


    }

    public void populateList()
    {
        contactAdapter= new ContactListAdapter();
        contactListView.setAdapter(contactAdapter);
    }

    private class ContactListAdapter extends ArrayAdapter<Contact> implements Filterable {

        public ContactListAdapter() {
            super(MainActivity.this, R.layout.listview_item, Contacts);
        }

        @Override
        public View getView(int position, View view, ViewGroup parent) {
            if (view == null)
                view = getLayoutInflater().inflate(R.layout.listview_item, parent, false);

            Contact currentContacts = Contacts.get(position);

            TextView name = (TextView) view.findViewById(R.id.name);
            name.setText(currentContacts.getName());

            TextView phone = (TextView) view.findViewById(R.id.phone);
            phone.setText(currentContacts.getPhone());

            TextView email = (TextView) view.findViewById(R.id.email);
            email.setText(currentContacts.getEmail());

            TextView address = (TextView) view.findViewById(R.id.address);
            address.setText(currentContacts.getAddress());

            ImageView img = (ImageView) view.findViewById(R.id.ivContact);
            img.setImageURI(currentContacts.getImgUri());
            imgUri = Uri.parse("android.resource://com.myFirstApp.contactmanager.cm/" + R.drawable.contact);

            return view;

        }

        @Override
        public android.widget.Filter getFilter() {

            if (searchFilter == null)
                searchFilter = new SearchFilter();
            return searchFilter;
        }

    }
        @Override
        public boolean onCreateOptionsMenu(Menu menu) {

            // Inflate the menu; this adds items to the action bar if it is present.
            getMenuInflater().inflate(R.menu.main, menu);
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
