package com.amigos.infotap.locateme;

import android.app.Activity;
import android.content.Context;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.util.List;
import java.util.Locale;


public class LocateActivity extends Activity {
    double lng;
    double lat;
    Geocoder gcd;
    TextView loc;
    List<Address> addresses;
    boolean gps_enabled = false;
    boolean network_enabled = false;
    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_locate);
        loc=(TextView)findViewById(R.id.textView);
        LocationManager lm = (LocationManager)getSystemService(Context.LOCATION_SERVICE);
        Location location = lm.getLastKnownLocation(LocationManager.NETWORK_PROVIDER);
if(location!=null) {
    lng = location.getLongitude();
    lat = location.getLatitude();
}
        gcd = new Geocoder(getApplicationContext(), Locale.getDefault());

        try
       {
           addresses = gcd.getFromLocation(51.5,-0.127, 1);
           System.out.println("Tryy");
           if (addresses.size() > 0) {
               System.out.println(addresses.get(0).getLocality());
           }
       }catch (IOException e)
       {
System.out.println("FAiled Network"+lat+lng);
       }
        gps_enabled = lm.isProviderEnabled(LocationManager.GPS_PROVIDER);
        network_enabled = lm.isProviderEnabled(LocationManager.NETWORK_PROVIDER);



        if (!gps_enabled && !network_enabled) {  Context context = getApplicationContext();
            int duration = Toast.LENGTH_SHORT;
            Toast toast = Toast.makeText(context, "nothing is enabled", duration);
            toast.show();
        }

            lm.requestLocationUpdates(LocationManager.GPS_PROVIDER, 2000, 10, new LocationListener() {
                @Override
                public void onLocationChanged(Location location) {
                    lng = location.getLongitude();
                    lat = location.getLatitude();
                    try {
                        addresses = gcd.getFromLocation(lat, lng, 1);
                        if (addresses.size() > 0) {
                            System.out.println(addresses.get(0).getLocality());
                            loc.setText(addresses.get(0).getLocality());
                        }
                    } catch (IOException e) {
                        System.out.println("Failed !!" + lat + lng);
                    }
                }

                @Override
                public void onStatusChanged(String provider, int status, Bundle extras) {

                }

                @Override
                public void onProviderEnabled(String provider) {

                }

                @Override
                public void onProviderDisabled(String provider) {

                }
            });
            lm.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, 2000, 10, new LocationListener() {
                @Override
                public void onLocationChanged(Location location) {
                    lng = location.getLongitude();
                    lat = location.getLatitude();
                    try {
                        addresses = gcd.getFromLocation(lat, lng, 1);
                        if (addresses.size() > 0) {
                            System.out.println(addresses.get(0).getLocality());
                            loc.setText(addresses.get(0).getLocality());
                        }
                    } catch (IOException e) {
                        System.out.println("Failed !!" + lat + lng);
                    }
                }

                @Override
                public void onStatusChanged(String provider, int status, Bundle extras) {

                }

                @Override
                public void onProviderEnabled(String provider) {

                }

                @Override
                public void onProviderDisabled(String provider) {

                }
            });
        }




    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.locate, menu);
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
