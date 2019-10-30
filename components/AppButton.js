import React, { Component } from 'react';
import { StyleSheet, View, Text, Button } from 'react-native';
import { purple, white } from '../utils/colors';
import DeckItem from './DeckItem';
import { TouchableOpacity } from 'react-native-gesture-handler';

class AppButton extends Component {
	render() {
		const disabled =
			this.props.disabled ? true :
			false;
		return (
			<TouchableOpacity onPress={this.props.onPress} disabled={disabled}>
				<View
					style={[
						styles.container,
						this.props.style,
						{
							backgroundColor:
								disabled ? 'grey' :
								purple
						}
					]}
				>
					<Text
						style={[
							styles.item,
							this.props.style,
							{
								backgroundColor:
									disabled ? 'grey' :
									purple
							}
						]}
					>
						{this.props.title}
					</Text>
				</View>
			</TouchableOpacity>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		borderWidth: 1,
		padding: 5,
		borderRadius: 5,
		margin: 10,
		justifyContent: 'center',
		width: 200,
		alignSelf: 'center',
		backgroundColor: purple
	},
	item: {
		textAlign: 'center',
		alignSelf: 'center',
		fontSize: 20,
		color: white
	}
});

export default AppButton;
