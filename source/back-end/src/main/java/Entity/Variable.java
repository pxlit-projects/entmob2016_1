package Entity;

import java.sql.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Variables")
public class Variable {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int variable_id;
	private String description;
	private Double value;
	private Date time;
	
	public int getVariable_id() {
		return variable_id;
	}
	public void setVariable_id(int variable_id) {
		this.variable_id = variable_id;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public Double getValue() {
		return value;
	}
	public void setValue(Double value) {
		this.value = value;
	}
	public Date getTime() {
		return time;
	}
	public void setTime(Date time) {
		this.time = time;
	}
	
}
