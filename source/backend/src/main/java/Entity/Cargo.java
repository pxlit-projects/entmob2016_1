package Entity;

class Cargo {

	private int _cargoId;
	private int _sensorId;
	private int _driverId;
	private int _destinationId;
	private float _weight;
	
	private int getCargoId() { return _cargoId; }
	private int getSensorId() { return _sensorId; }
	private int getDriverId() { return _driverId; }
	private int getDestinationId() { return _destinationId; }
	private float getWeight() { return _weight; }
	
	private void setCargoId(int id) {
		_cargoId = id;
	}
	
	private void setSensorId(int id) {
		_sensorId = id;
	}
	
	private void setDriverId(int id) {
		_driverId = id;
	}
	
	private void setDestinationId(int id) {
		_destinationId = id;
	}
	
	private void setWeight(float weight) {
		_weight = weight;
	}
}
