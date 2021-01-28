//
//  File.swift
//  LABS3
//
//  Created by Student on 23/01/2021.
//  Copyright © 2021 Klaudia Janecka. All rights reserved.
//

import Foundation
import UIKit
import CoreLocation

class ThirdViewController: UIViewController, CLLocationManagerDelegate
{

    @IBOutlet weak var thirdLabel: UILabel!
    @IBOutlet weak var latitudeLabel: UILabel!
    @IBOutlet weak var longitudeLabel: UILabel!
    
    @IBOutlet weak var adressLabel: UILabel!
    @IBOutlet weak var getLocation: UIButton!
    @IBOutlet weak var getAdress: UIButton!
    
    let locationManager = CLLocationManager()
    var location: CLLocation?
    
    //------------------------------------------------//
    //Geocoding
    
    let geocoder = CLGeocoder()
    var  placemark: CLPlacemark?
    var  performingReverseGeocoding = false
    var  lastGeocodingError: Error?
    
    func showLocationServicesDeniedAlert(){
        let alert = UIAlertController(
            title: "Location Services Disabled",
            message: "Please enable location for this app in Settings",
            preferredStyle: .alert)
        
        let okAction = UIAlertAction(
            title: "OK",
            style: .default,
            handler: nil)
        
        alert.addAction(okAction)
        present(alert, animated: true, completion: nil)
    }
    func locationName(from placemark: CLPlacemark) -> String{
        return "\(placemark.subThoroughfare!) \(placemark.thoroughfare!)\n\(placemark.locality!) \(placemark.administrativeArea!) \(placemark.postalCode!)"
    }
    @IBAction func getLocation(_ sender: UIButton) {
        let authStatus: CLAuthorizationStatus = CLLocationManager.authorizationStatus()
        if authStatus == .notDetermined{
            locationManager.requestWhenInUseAuthorization()
            return
        }
        if authStatus == .denied || authStatus == .restricted{
            showLocationServicesDeniedAlert()
            return
        }
        
        locationManager.delegate = self
        locationManager.desiredAccuracy = kCLLocationAccuracyNearestTenMeters
        locationManager.startUpdatingLocation()
    }
    
    func locationManager(_ manager: CLLocationManager, didFailWithError error: Error){
        print("didFailWithError\(error)")
    }

    
    func locationManager(_ manager: CLLocationManager, didUpdateLocations locations: [CLLocation]){
        let newLocation = locations.last!
        print("didUpdateLocations\(newLocation)")
        location = newLocation
        if let location = location{
            latitudeLabel.text = String(format: "%.6f", location.coordinate.latitude)
            longitudeLabel.text = String(format: "%.6f", location.coordinate.longitude)
        }
    }
    
    @IBAction func getAddress() {
        if !performingReverseGeocoding{
            if location == nil{
                self.adressLabel.text = "There is no location"
                self.placemark = nil
                return
            }
            print("Performing reverse geocoding")
            performingReverseGeocoding = true
            geocoder.reverseGeocodeLocation(location!, completionHandler: {
                placemarks, error in print("Address:\(String(describing: placemarks)), error: \(String(describing: error))")
                if error == nil,let p = placemarks, !p.isEmpty {
                    self.placemark = p.last!
                    self.adressLabel.text = self.locationName(from: self.placemark!)
                    self.performingReverseGeocoding = false
                }
                else{
                    self.placemark = nil
                }
            })
        }
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
}
}
