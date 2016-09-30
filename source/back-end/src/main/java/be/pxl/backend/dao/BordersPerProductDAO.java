package be.pxl.backend.dao;

import java.util.List;

import be.pxl.backend.entity.BordersPerProduct;

public interface BordersPerProductDAO {
	public List<BordersPerProduct> getBorderPerProductByProductId(int id);
	public void updateBordersPerProduct(BordersPerProduct bpp);
	public void deleteBordersPerProduct(BordersPerProduct bpp);
}
