package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import javax.persistence.*;

@Entity
@Table(name = "cargo_border")
public class CargoBorder {
    
    @Id
    @GeneratedValue (strategy=GenerationType.AUTO)
    private int cargo_border_id;
    private float value;
    @ManyToOne
    @JsonBackReference(value = "cargos_borders")
    private Cargo cargo;
    @ManyToOne
    private Variable variable;
    
    public Variable getVariable() {
        return variable;
    }
    public int getCargo_border_id() { return cargo_border_id; }
    public float getValue() { return value; }
    
}
