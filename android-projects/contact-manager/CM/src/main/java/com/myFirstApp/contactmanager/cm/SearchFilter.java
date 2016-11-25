package com.myFirstApp.contactmanager.cm;

import android.util.Log;

import java.util.ArrayList;
import java.util.logging.Filter;

/**
 * Created by $@T!$# on 09-10-2014.
 */
public class SearchFilter extends android.widget.Filter {
    @Override
    protected FilterResults performFiltering(CharSequence constraint) {
        FilterResults results = new FilterResults();
        // We implement here the filter logic
        ArrayList<Contact> contacts = new ArrayList<Contact>();
        contacts.addAll(MainActivity.dbHandler.getAllContacts());
        if (constraint == null || constraint.length() == 0) {
            // No filter implemented we return all the list
            results.values = contacts;
            results.count = contacts.size();
        }
        else {
            // We perform filtering operation
           ArrayList<Contact> nPlanetList = new ArrayList<Contact>();

            for (Contact p : contacts) {
                if (p.getName().toUpperCase().startsWith(constraint.toString().toUpperCase()) || constraint.toString().equals(""))
                    nPlanetList.add(p);
            }

            results.values = nPlanetList;
            results.count = nPlanetList.size();

        }
        return results;
    }

    @Override
    protected void publishResults(CharSequence constraint,
                                  FilterResults results) {

        // Now we have to inform the adapter about the new list filtered
        if (results.count == 0)
            MainActivity.contactAdapter.notifyDataSetInvalidated();
        else {
            MainActivity.Contacts.clear();
            MainActivity.Contacts.addAll((ArrayList<Contact>) results.values);
            MainActivity.contactAdapter.notifyDataSetChanged();
        }

    }


}
